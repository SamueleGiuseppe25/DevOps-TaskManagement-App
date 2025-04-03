import requests

BASE_URL = "http://localhost:5053/api/Task"

def test_get_all_tasks():
    response = requests.get(BASE_URL)
    assert response.status_code == 200
    assert isinstance(response.json(), list)

def test_create_task():
    task_data = {
        "title": "My first QA test",
        "description": "Created by automated test",
        "priority": "Medium",
        "status": "Pending"
    }
    response = requests.post(BASE_URL, json=task_data)
    assert response.status_code in [200, 201]
    created_task = response.json()
    assert created_task["title"] == task_data["title"]
    assert created_task["status"] == task_data["status"]

def test_delete_task():
    task_data = {
        "title": "To be deleted",
        "description": "Delete me",
        "priority": "Low",
        "status": "Pending"
    }
    create_response = requests.post(BASE_URL, json=task_data)
    task = create_response.json()
    task_id = task.get("id")
    delete_response = requests.delete(f"{BASE_URL}/{task_id}")
    assert delete_response.status_code in [200, 204]  # Accept either

