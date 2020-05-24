import { Component, OnInit } from '@angular/core';
import { QuizService } from '../quiz/services/quiz.service';
import { QuizResultModel } from '../quiz/models/quiz-result.model';
import { QuizModel } from './models/quiz.model';
import { QuizAnswer } from './models/quiz-answer.model';
import { QuestionModel } from '../question/models/question.model';
import { FinishQuizCommandModel } from './models/finish-quiz-command.model';

@Component({
    selector: 'app-quiz',
    templateUrl: './quiz.component.html',
    styles: [`
        table tr td:nth-child(1) {
            width: 10%;
        }
    `]
})
export class QuizComponent implements OnInit {
    quiz: QuizModel;
    userName = '';
    actualQuestionIndex = 0;
    checkedId: string;
    answers: QuizAnswer[];
    question: QuestionModel;
    canFinish: boolean;
    result: number;
    resultMessage: string;
    finished: boolean;

    constructor(private service: QuizService) {
    }

    ngOnInit(): void {

    }

    start() {
        this.actualQuestionIndex = 0;
        this.result = this.checkedId = null;
        this.finished = this.canFinish = false;
        this.answers = new Array<QuizAnswer>();
        this.service.Start(this.userName).subscribe(result => {
            if (!result.success) {
                alert(result.message);
                return;
            }
            this.quiz = result.value;
            this.question = result.value.questions[0];
        }, error => alert(error));
    }

    addAnswer() {
        this.answers.push(new QuizAnswer(this.question.id, this.checkedId));
    }

    next() {
        this.addAnswer();
        this.actualQuestionIndex++;
        this.question = this.quiz.questions[this.actualQuestionIndex];
        this.canFinish =  this.quiz.questions.length - 1 === this.actualQuestionIndex;
        this.checkedId = null;
    }

    finish() {
        this.addAnswer();
        const command = new FinishQuizCommandModel(this.userName, this.answers);
        this.service.Finish(command).subscribe(result => {
            if (!result.success) {
                alert(result.message);
                return;
            }
            debugger;
            this.result = result.value.result;
            this.verifyResult();
            this.finished = true;
        }, error => alert(error));
    }

    verifyResult() {
        if (this.result >= 80)
            this.resultMessage = "Parabéns!!!";
        else if (this.result >= 50)
            this.resultMessage = "Você está no caminho certo!";
        else if (this.result <= 20)
            this.resultMessage = "Em que caverna você vive?!?!?!";
    }
}
