require 'albacore'
require 'yaml'
require 'fileutils'

task :default => [:build, :test]

desc "Build Project"
msbuild :build do |msb|
  msb.properties :configuration => :Debug
  msb.targets :Clean, :Build
  msb.solution = "IndiaApplication.sln"
end

desc "Run Tests"
nunit :test do |nunit|
	nunit.command = "packages/NUnit.2.5.10.11092/tools/nunit-console.exe"
	nunit.assemblies "IndiaApplication.unit.test/bin/Debug/IndiaApplication.unit.test.dll"
end

desc "Package application"
zip :package => :copy_to_output do |zip| 
  zip.directories_to_zip "build"
  zip.output_file = "IndiaApplication.zip"
  zip.output_path = File.dirname(__FILE__) + "/build"
end

msbuild :copy_to_output do |msb|
	msb.properties  :configuration => :Release, "_PackageTempDir" => "../build", "AutoParameterizationWebConfigConnectionStrings" => :false
	msb.targets :Build, :PipelinePreDeployCopyAllFilesToOneFolder
	msb.solution = "IndiaApplication/IndiaApplication.csproj"
end

desc "Deploy to target environment"
task :deploy, [:env] do |t, args|
  configuration = YAML.load_file "deploy.yml"
  target_dir = configuration[args['env']]['target_dir']
  Dir.foreach(target_dir) {|f| fn = File.join(target_dir, f); FileUtils.rm_r(fn) if f != '.' && f != '..'}
  FileUtils.cp_r("build/IndiaApplication.zip", target_dir)
  Rake::Task[:extract].invoke(target_dir)
  Rake::Task[:update_config].invoke(args['env'])
end

unzip :extract, [:target_dir] do |unzip, args|
	unzip.file = "#{args['target_dir']}/IndiaApplication.zip"
	unzip.destination = args['target_dir']
end

task :update_config, [:env] do |t, args|
	doc = File.open('IndiaApplication/web.config.template', 'rb') { |f| f.read }
	configuration = YAML.load_file "#{args['env']}.yml"	
  deploy_config = YAML.load_file "deploy.yml"	
	configuration.each_pair { |key, value|
		puts "#{key} = #{value}"
		doc = doc.gsub(/\$\{#{key}\}/, value)
	}
	File.open("#{deploy_config[args['env']]['target_dir']}/web.config", 'w') { |f| f.write(doc) }
end
