const { expect } = require('chai');
const { isTaskValid } = require('../js/taskUtils');

describe('isTaskValid()', () => {
    it('should return true when task has title and dueDate', () => {
        const task = { title: 'Test Task', dueDate: '2025-04-01T10:00:00Z' };
        expect(isTaskValid(task)).to.be.true;
    });

    it('should return false if title is missing', () => {
        const task = { dueDate: '2025-04-01T10:00:00Z' };
        expect(isTaskValid(task)).to.be.false;
    });

    it('should return false if dueDate is missing', () => {
        const task = { title: 'Test Task' };
        expect(isTaskValid(task)).to.be.false;
    });
});
