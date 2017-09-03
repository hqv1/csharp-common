def nuget_path = env.NugetPath
def nuget_server = env.HqvNugetServer
def nuget_server_key = env.HqvNugetServerKey
 
stage('compile') {
    node('windows') {
		checkout scm
        // git 'https://github.com/hqv1/csharp-common.git' 
        bat 'dotnet clean'
        bat 'dotnet restore'
        bat 'dotnet build -c Release'
        stash 'everything'
    }
}
 
stage('test') {
    node('windows') {
        unstash 'everything'
		dir("Common.App.Test") {
            bat 'dotnet restore'
            bat 'dotnet test --filter Category=Unit'
        }	
		dir("Common.Audit.Logging.Serilog.Test") {
            bat 'dotnet restore'
            bat 'dotnet test --filter Category=Unit'
        }	
		dir("Common.Logging.NLog.Test") {
            bat 'dotnet restore'
            bat 'dotnet test --filter Category=Unit'
        }	
        dir("Common.Test") {
            bat 'dotnet restore'
            bat 'dotnet test --filter Category=Unit'
        }		
    }
}
 
stage('publish') {
    node('windows') {
        unstash 'everything'
        bat 'del /S *.nupkg'
        dir("Common") {
            bat 'dotnet pack --no-build -c Release'
        }
		dir("Common.App") {
            bat 'dotnet pack --no-build -c Release'
        }
		dir("Common.Audit.Logging") {
            bat 'dotnet pack --no-build -c Release'
        }
		dir("Common.Logging.NLog") {
            bat 'dotnet pack --no-build -c Release'
        }
		dir("Common.Logging.Serilog") {
            bat 'dotnet pack --no-build -c Release'
        }
        dir("Common.Web") {
            bat 'dotnet pack --no-build -c Release'
        }
		dir("Common.Web.Client") {
            bat 'dotnet pack --no-build -c Release'
        }
        bat "${nuget_path} push **\\*.nupkg ${nuget_server_key} -Source ${nuget_server}"
        archiveArtifacts '**\\*.nupkg'
    }
}
