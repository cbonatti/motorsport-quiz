import { Component, OnInit } from '@angular/core';
import { QuizService } from '../quiz/services/quiz.service';
import { QuizResultModel } from '../quiz/models/quiz-result.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  quizzes: QuizResultModel[];

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
