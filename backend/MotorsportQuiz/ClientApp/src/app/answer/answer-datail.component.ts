import { Component, OnInit } from '@angular/core';
import { AnswerService } from './services/answer.service';
import { AnswerModel } from './models/answer.model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'app-answer-detail',
    templateUrl: './answer-datail.component.html',
})
export class AnswerDetailComponent implements OnInit {
    answer: AnswerModel;

    constructor(private service: AnswerService, private route: ActivatedRoute, private router: Router) {
        this.answer = new AnswerModel();
    }

    ngOnInit(): void {
        let id = this.route.snapshot.paramMap.get('id');
        if (id) {
            this.loadAnswer(id);
        }
    }

    loadAnswer(id: string) {
        this.service.GetAnswer(id).subscribe(result => {
            if (!result.success) {
                alert(result.message);
                return;
            }
            this.answer = result.value;
        }, error => alert(error));
    }

    save() {
        let serviceCall;
        if (this.answer.id)
            serviceCall = this.service.Update(this.answer);
        else
            serviceCall = this.service.Add(this.answer);

        serviceCall.subscribe(result => {
            if (!result.success) {
                alert(result.message);
                return;
            }
            alert('Resposta salva com sucesso');
            this.router.navigate(['answers']);
        }, error => alert(error));
    }
}
