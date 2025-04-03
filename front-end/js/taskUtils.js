function isTaskValid(task) {
    return !!(task.title && task.dueDate);
}

module.exports = { isTaskValid };
