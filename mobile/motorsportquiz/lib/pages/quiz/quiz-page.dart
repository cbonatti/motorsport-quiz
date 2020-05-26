import 'package:flutter/material.dart';
import 'package:fluttertoast/fluttertoast.dart';
import 'package:motorsportquiz/pages/quiz-ranking/models/quiz-ranking.dart';
import 'package:motorsportquiz/pages/quiz/models/answer.dart';
import 'package:motorsportquiz/pages/quiz/models/question.dart';

import 'models/quiz-answer.dart';
import 'quiz-result-page.dart';
import 'services/quiz-service.dart';

class QuizPage extends StatefulWidget {
  QuizPage({@required this.userName, @required this.questions});
  final String userName;
  final List<Question> questions;

  @override
  _QuizPageState createState() => _QuizPageState();
}

class _QuizPageState extends State<QuizPage> {
  final QuizService _quizService = QuizService();
  int _index = 0;
  Answer _answer;
  List<QuizAnswer> _answers = [];
  List<Question> questions = [];
  String nextButtonText = "Próxima";

  @override
  void initState() {
    super.initState();
    questions = widget.questions;
  }

  void _addAnswer() {
    _answers.add(
        QuizAnswer(questionId: questions[_index].id, answerId: _answer.id));
    _answer = null;
  }

  bool _isLastQuestion() => _index == questions.length - 1;

  void _next() {
    setState(() {
      _addAnswer();

      if (_isLastQuestion()) {
        _finish();
        return;
      }

      _index++;
      if (_isLastQuestion()) {
        nextButtonText = "Finalizar";
      }
    });
  }

  void _finish() {
    _quizService
        .finish(widget.userName, _answers)
        .then((value) => {navigate(value.result)});
  }

  void navigate(double result) {
    Navigator.push(
      context,
      MaterialPageRoute(
        builder: (_) => QuizResultPage(
          result:
              QuizRanking(position: 0, name: widget.userName, result: result),
        ),
      ),
    );
  }

  Future<bool> _blockReturn() {
    Fluttertoast.showToast(
      backgroundColor: Colors.indigo,
      textColor: Colors.white,
      msg: 'Finalize o quiz para voltar',
      toastLength: Toast.LENGTH_LONG,
      gravity: ToastGravity.BOTTOM,
      timeInSecForIos: 1,
    );
    return Future.value(false);
  }

  List<Widget> createAnswerList() {
    List<Widget> list = [];
    for (var answer in questions[_index].answers) {
      list.add(RadioListTile(
        value: answer,
        groupValue: _answer,
        title: Text(answer.name),
        onChanged: (currentAnswer) {
          setSelectedAnswer(answer);
        },
        selected: _answer == answer,
      ));
    }
    return list;
  }

  setSelectedAnswer(Answer answer) {
    setState(() {
      _answer = answer;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      bottomNavigationBar: FlatButton(
        color: Colors.indigo,
        textColor: Colors.white,
        onPressed: _answer != null ? _next : null,
        child: Text(
          nextButtonText,
          style: TextStyle(fontSize: 20.0),
        ),
      ),
      appBar: AppBar(
        title: Text('Motorsport Quiz'),
      ),
      body: WillPopScope(
        onWillPop: () async {
          return _blockReturn();
        },
        child: Padding(
            padding: EdgeInsets.all(20.0),
            child: Column(
                crossAxisAlignment: CrossAxisAlignment.stretch,
                children: <Widget>[
                  Center(
                    child: Text(
                      'Questão ${_index + 1} - ${questions[_index].name}',
                      style:
                          TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
                    ),
                  ),
                  Column(
                    children: createAnswerList(),
                  ),
                ])),
      ),
    );
  }
}
