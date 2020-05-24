export class QuizAnswer {
    questionId: string;
    answerId: string;

    constructor(question: string, answer: string) {
        this.questionId = question;
        this.answerId = answer;
    }
}