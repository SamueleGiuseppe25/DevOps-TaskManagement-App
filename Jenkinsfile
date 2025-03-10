pipeline {
    agent any
    environment {
        DOCKER_IMAGE = "devops-task-management-app:latest"
    }
    stages {
        stage('Clone Repository') {
            steps {
                git branch: 'feature-branch', url: 'https://github.com/SamueleGiuseppe25/DevOps-TaskManagement-App.git'
            }
        }

        stage('Build Docker Image') {
            steps {
                script {
                    bat "docker build -t %DOCKER_IMAGE% ."
                }
            }
        }

        stage('Push Docker Image') {
            steps {
                withDockerRegistry([credentialsId: 'docker-hub-credentials', url: '']) {
                    bat 'docker push %DOCKER_IMAGE%'
                }
            }
        }

        stage('Deploy') {
            steps {
                bat 'docker run -d -p 5000:5000 %DOCKER_IMAGE%'
            }
        }
    }
}
