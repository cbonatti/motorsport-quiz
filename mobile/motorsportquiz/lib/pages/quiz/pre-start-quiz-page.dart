import 'package:flutter/material.dart';

import 'quiz-page.dart';

class PreStartQuizPage extends StatefulWidget {
  @override
  _PreStartQuizPageState createState() => _PreStartQuizPageState();
}

class _PreStartQuizPageState extends State<PreStartQuizPage> {
  String userName = '';

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
        onPressed: userName == '' ? null : _startQuiz,
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
                userName = text;
              });
            },
            decoration: InputDecoration(labelText: 'Informe seu nome'),
          )),
    );
  }
}
