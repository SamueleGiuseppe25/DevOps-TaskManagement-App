pipeline {
    agent any
    environment {
        DOCKER_IMAGE = "samuelegiuseppe25/devops-taskmanagement-app"
    }
    stages {
        stage('Clone Repository') {
            steps {
                git branch: 'feature-branch', url: 'https://github.com/SamueleGiuseppe25/DevOps-TaskManagement-App.git'
            }
        }

        stage('Build Docker Image') {
            steps {
                sh 'docker build -t $DOCKER_IMAGE .'
            }
        }

        stage('Run Tests') {
            steps {
                sh 'docker run --rm $DOCKER_IMAGE pytest' // Adjust if needed
            }
        }

        stage('Push Docker Image') {
            steps {
                withDockerRegistry([credentialsId: 'docker-hub-credentials', url: '']) {
                    sh 'docker push $DOCKER_IMAGE'
                }
            }
        }

        stage('Deploy') {
            steps {
                sh 'docker run -d -p 5000:5000 $DOCKER_IMAGE'
            }
        }
    }
}
