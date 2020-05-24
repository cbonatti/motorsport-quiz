import { QuizAnswer } from "./quiz-answer.model";

export class FinishQuizCommandModel {
    userName: string;
    answers: QuizAnswer[];

    constructor(userName: string, answers: QuizAnswer[]) {
        this.userName = userName;
        this.answers = answers;
    }
}