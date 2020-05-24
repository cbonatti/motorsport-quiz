import { Component, OnInit } from '@angular/core';
import { QuestionModel } from './models/question.model';
import { QuestionService } from './services/question.service';

@Component({
    selector: 'app-question',
    templateUrl: './question.component.html',
    styles: [`
        table tr td:nth-child(2) {
            width: 20%;
        }

        @media screen and (min-width: 771px) and (max-width: 990px) {
            table tr td:nth-child(2) {
                width: 30%;
            }
        }

        @media screen and (max-width: 770px) {
            table tr td:nth-child(2) {
                width: 40%;
            }
        }
    `]
})
export class QuestionComponent implements OnInit {
    questions: QuestionModel[];

    constructor(private service: QuestionService) {
    }

    ngOnInit(): void {
        this.loadQuestions();
    }

    remove(id: string) {
        if (confirm('Deseja mesmo excluir?')) {
            this.service.Delete(id).subscribe(result => {
                if (!result.success) {
                    alert(result.message);
                    return;
                }
                alert('Pergunta excluída');
                this.loadQuestions();
            });
        }
    }

    loadQuestions() {
        this.service.GetQuestions().subscribe(result => {
            if (!result.success) {
                alert(result.message);
                return;
            }
            this.questions = result.value;
        }, error => alert(error));
    }
}
