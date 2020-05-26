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
  bool _canFinish = false;
  List<Question> questions = [];

  @override
  void initState() {
    super.initState();
    questions = widget.questions;
  }

  void _checkCanFinish() {
    _canFinish = _index == questions.length - 1;
  }

  void _addAnswer() {
    _answers.add(
        QuizAnswer(questionId: questions[_index].id, answerId: _answer.id));
  }

  void _next() {
    setState(() {
      _addAnswer();
      _index++;
      _checkCanFinish();
    });
  }

  void _finish() {
    _addAnswer();
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
      appBar: AppBar(
        title: Text('Motorsport Quiz'),
        actions: <Widget>[
          IconButton(
            icon: const Icon(Icons.redo),
            tooltip: 'Próxima',
            disabledColor: Colors.grey,
            onPressed: !_canFinish && _answer != null ? _next : null,
          ),
          IconButton(
            icon: const Icon(Icons.publish),
            tooltip: 'Finalizar',
            disabledColor: Colors.grey,
            onPressed: _canFinish && _answer != null ? _finish : null,
          ),
        ],
      ),
      body: WillPopScope(
        onWillPop: () async {
          return _blockReturn();
        },
        child: Padding(
            padding: EdgeInsets.fromLTRB(20, 20, 20, 20),
            child: Column(
                crossAxisAlignment: CrossAxisAlignment.stretch,
                children: <Widget>[
                  Text('Questão ${_index + 1} - ${questions[_index].name}'),
                  Column(
                    children: createAnswerList(),
                  ),
                ])),
      ),
    );
  }
}
