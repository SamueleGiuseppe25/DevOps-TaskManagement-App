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
                    // Use 'sh' for Unix-based systems and 'bat' for Windows
                    if (isUnix()) {
                        sh 'docker build -t $DOCKER_IMAGE .'
                    } else {
                        bat 'docker build -t %DOCKER_IMAGE% .'
                    }
                }
            }
        }

        stage('Push Docker Image') {
            steps {
                script {
                    // Use 'sh' for Unix-based systems and 'bat' for Windows
                    if (isUnix()) {
                        withDockerRegistry([credentialsId: 'docker-hub-credentials', url: '']) {
                            sh 'docker push $DOCKER_IMAGE'
                        }
                    } else {
                        withDockerRegistry([credentialsId: 'docker-hub-credentials', url: '']) {
                            bat 'docker push %DOCKER_IMAGE%'
                        }
                    }
                }
            }
        }

        stage('Deploy') {
            steps {
                script {
                    // Deploy the Docker container
                    if (isUnix()) {
                        sh 'docker run -d -p 5000:5000 $DOCKER_IMAGE'
                    } else {
                        bat 'docker run -d -p 5000:5000 %DOCKER_IMAGE%'
                    }
                }
            }
        }
    }
}
