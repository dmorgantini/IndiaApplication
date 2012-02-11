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

