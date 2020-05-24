import { QuestionAnswerModel } from "./question-answer.model";

export class QuestionModel {
    id: string;
    name: string;
    answers: QuestionAnswerModel[];

    constructor() {
        this.answers = new Array<QuestionAnswerModel>();
    }
}