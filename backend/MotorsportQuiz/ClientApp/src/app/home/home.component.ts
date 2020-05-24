import { Component, OnInit } from '@angular/core';
import { QuizService } from './services/quiz.service';
import { QuizModel } from './models/quiz.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  quizzes: QuizModel[];

  constructor(private service: QuizService) {

  }

  ngOnInit(): void {
    this.service.GetScores().subscribe(x => {
      if (!x.success) {
        alert(x.message);
        return;
      }
      this.quizzes = x.value;
    }, error => alert(error));
  }
}
