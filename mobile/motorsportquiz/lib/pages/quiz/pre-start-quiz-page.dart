import 'package:flutter/material.dart';

import 'models/question.dart';
import 'quiz-page.dart';
import 'services/quiz-service.dart';

class PreStartQuizPage extends StatefulWidget {
  @override
  _PreStartQuizPageState createState() => _PreStartQuizPageState();
}

class _PreStartQuizPageState extends State<PreStartQuizPage> {
  final QuizService _quizService = QuizService();
  String _userName = '';

  void _startQuiz() {
    _quizService.start(_userName).then((value) => {navigate(value)});
  }

  void navigate(List<Question> questions) {
    Navigator.push(
      context,
      MaterialPageRoute(
        builder: (_) => QuizPage(
          userName: _userName,
          questions: questions,
        ),
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      bottomNavigationBar: FlatButton(
        color: Colors.indigo,
        textColor: Colors.white,
        disabledColor: Colors.grey[300],
        disabledTextColor: Colors.black,
        padding: EdgeInsets.all(8.0),
        splashColor: Colors.indigoAccent,
        onPressed: _userName == '' ? null : _startQuiz,
        child: Text(
          "Iniciar",
          style: TextStyle(fontSize: 20.0),
        ),
      ),
      appBar: AppBar(
        title: Text('Motorsport Quiz'),
      ),
      body: Padding(
          padding: EdgeInsets.fromLTRB(20, 20, 20, 20),
          child: TextFormField(
            onChanged: (text) {
              setState(() {
                _userName = text;
              });
            },
            decoration: InputDecoration(labelText: 'Informe seu nome'),
          )),
    );
  }
}
