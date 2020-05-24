import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { QuestionModel } from './models/question.model';
import { QuestionService } from './services/question.service';
import { AnswerService } from '../answer/services/answer.service';
import { AnswerModel } from '../answer/models/answer.model';
import { QuestionAnswerModel } from './models/question-answer.model';

@Component({
    selector: 'app-question-detail',
    templateUrl: './question-datail.component.html',
    styles: [`
        .questionAnswer tr td:nth-child(1) {
            width: 10%;
        }
        .questionAnswer tr td:nth-child(3),
        .answer tr td:nth-child(2) {
            width: 20%;
        }

        @media screen and (min-width: 771px) and (max-width: 990px) {
            .questionAnswer tr td:nth-child(3),
            .answer tr td:nth-child(2) {
                width: 30%;
            }
        }

        @media screen and (max-width: 770px) {
            .questionAnswer tr td:nth-child(3),
            .answer tr td:nth-child(2) {
                width: 40%;
            }
        }
    `]
})
export class QuestionDetailComponent implements OnInit {
    question: QuestionModel;
    answers: AnswerModel[];
    checkedId: string;

    constructor(private service: QuestionService,
        private route: ActivatedRoute,
        private router: Router,
        private answerService: AnswerService) {
        this.question = new QuestionModel();
    }

    ngOnInit(): void {
        let id = this.route.snapshot.paramMap.get('id');
        if (id)
            this.loadQuestion(id);
        else
            this.loadAnswers();
    }

    loadQuestion(id: string) {
        this.service.GetQuestion(id).subscribe(result => {
            if (!result.success) {
                alert(result.message);
                return;
            }
            this.question = result.value;
            this.checkedId = result.value.answers.find(answer => answer.correct).id;
            this.loadAnswers();
        }, error => alert(error));
    }

    loadAnswers() {
        this.answerService.GetAnswers().subscribe(result => {
            if (!result.success) {
                alert(result.message);
                return;
            }
            if (this.question.answers && this.question.answers.length > 0)
                this.answers = result.value.filter(answer => !this.question.answers.some(questionAnswer => questionAnswer.id === answer.id));
            else
                this.answers = result.value
        })
    }

    remove(answer: QuestionAnswerModel) {
        if (this.checkedId === answer.id)
            this.checkedId = null;

        this.answers.push({ id: answer.id, name: answer.name, canBeRemoved: true });
        const index = this.question.answers.findIndex(questionAnswer => questionAnswer.id === answer.id);
        this.question.answers.splice(index, 1);
    }

    add(answer: AnswerModel) {
        this.question.answers.push({ id: answer.id, name: answer.name, correct: false });
        const index = this.answers.findIndex(x => x.id === answer.id);
        this.answers.splice(index, 1);
    }

    save() {
        let serviceCall;
        this.question.answers.map(answer => {
            if (answer.id === this.checkedId)
                answer.correct = true;
            else
                answer.correct = false;
        });

        if (this.question.id)
            serviceCall = this.service.Update(this.question);
        else
            serviceCall = this.service.Add(this.question);

        serviceCall.subscribe(result => {
            if (!result.success) {
                alert(result.message);
                return;
            }
            alert('Pergunta salva com sucesso');
            this.router.navigate(['questions']);
        }, error => alert(error));
    }
}
