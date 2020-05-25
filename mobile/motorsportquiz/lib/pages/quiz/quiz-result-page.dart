import 'package:flutter/material.dart';
import 'package:motorsportquiz/pages/quiz-ranking/models/quiz-ranking.dart';

import 'quiz-page.dart';

class QuizResultPage extends StatefulWidget {
  QuizResultPage({@required this.result});
  final QuizRanking result;

  @override
  _QuizResultPageState createState() => _QuizResultPageState();
}

class _QuizResultPageState extends State<QuizResultPage> {
  String userName = '';

  _QuizResultPageState() {
    //userName = widget.result.name;
  }

  void _startQuiz() {
    Navigator.push(
      context,
      MaterialPageRoute(
        builder: (_) => QuizPage(
          userName: userName,
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
        onPressed: _startQuiz,
        child: Text(
          "Reiniciar",
          style: TextStyle(fontSize: 20.0),
        ),
      ),
      appBar: AppBar(
        title: Text('Motorsport Quiz'),
      ),
      body: Padding(
          padding: EdgeInsets.fromLTRB(20, 20, 20, 20),
          child: Text('Seu resultado ${widget.result.result}')),
    );
  }
}
