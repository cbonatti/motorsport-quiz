import { Component, OnInit } from '@angular/core';
import { AnswerService } from './services/answer.service';
import { AnswerModel } from './models/answer.model';

@Component({
    selector: 'app-answer',
    templateUrl: './answer.component.html',
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
export class AnswerComponent implements OnInit {
    answers: AnswerModel[];

    constructor(private service: AnswerService) {
    }

    ngOnInit(): void {
        this.loadAnswers();
    }

    remove(id: string) {
        if (confirm('Deseja mesmo excluir?')) {
            this.service.Delete(id).subscribe(result => {
                if (!result.success) {
                    alert(result.message);
                    return;
                }
                alert('Resposta excluída');
                this.loadAnswers();
            });
        }
    }

    loadAnswers() {
        this.service.GetAnswers().subscribe(result => {
            if (!result.success) {
                alert(result.message);
                return;
            }
            this.answers = result.value;
        }, error => alert(error));
    }
}
