pipeline {
    agent any

    environment {
        DOTNET_SDK_VERSION = '3.1.401'
        ASPNETCORE_ENVIRONMENT = 'Production'
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Build') {
            steps {
                script {
                    def dotnetHome = tool name: "DotNetCore", type: 'maven', label: ''
                    env.PATH = "${dotnetHome}/bin:${env.PATH}"

                    sh "dotnet --version"
                    sh "dotnet restore"
                    sh "dotnet build --configuration Release"
                }
            }
        }

        stage('Test') {
            steps {
                script {
                    sh "dotnet test --no-restore --verbosity normal"
                }
            }
        }

        stage('Publish') {
            steps {
                script {
                    sh "dotnet publish -c Release -o ./publish"
                }
            }
        }
    }

    post {
        success {
            archiveArtifacts artifacts: 'publish/**/*', fingerprint: true
        }
        failure {
            echo "The pipeline has failed!"
        }
    }
}
