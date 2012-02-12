require 'albacore'

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
zip :package, [:build_number] => :copy_to_output do |zip, args| 
    zip.directories_to_zip "build"
    zip.output_file = "IndiaApplication.v#{args["build_number"]}.zip"
    zip.output_path = File.dirname(__FILE__) + "/build"
end

msbuild :copy_to_output do |msb|
	msb.properties  :configuration => :Release, "_PackageTempDir" => "../build", "AutoParameterizationWebConfigConnectionStrings" => :false
	msb.targets :Build, :PipelinePreDeployCopyAllFilesToOneFolder
	msb.solution = "IndiaApplication/IndiaApplication.csproj"
end


