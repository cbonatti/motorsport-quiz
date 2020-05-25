import 'package:flutter/material.dart';
import 'package:fluttertoast/fluttertoast.dart';
import 'package:motorsportquiz/pages/quiz-ranking/models/quiz-ranking.dart';
import 'package:motorsportquiz/pages/quiz/models/answer.dart';
import 'package:motorsportquiz/pages/quiz/models/question.dart';

import 'models/quiz-answer.dart';
import 'models/quiz.dart';
import 'quiz-result-page.dart';

class QuizPage extends StatefulWidget {
  QuizPage({@required this.userName});
  final String userName;

  final Quiz quiz = Quiz(name: '', questions: <Question>[
    Question(id: '1', name: 'BMW', answers: <Answer>[
      Answer(id: '1', name: 'Alemanha'),
      Answer(id: '2', name: 'Inglaterra'),
    ]),
    Question(id: '1', name: 'Mini', answers: <Answer>[
      Answer(id: '1', name: 'Alemanha'),
      Answer(id: '2', name: 'Inglaterra'),
    ]),
  ]);

  @override
  _QuizPageState createState() => _QuizPageState();
}

class _QuizPageState extends State<QuizPage> {
  int index = 0;
  Answer answer;
  List<QuizAnswer> answers = [];
  bool canFinish = false;

  void checkCanFinish() {
    canFinish = index == widget.quiz.questions.length - 1;
  }

  void addAnswer() {
    answers.add(QuizAnswer(
        questionId: widget.quiz.questions[index].id, answerId: answer.id));
  }

  void next() {
    setState(() {
      addAnswer();
      answer = null;
      index++;
      checkCanFinish();
    });
  }

  void finish() {
    addAnswer();
    Navigator.push(
      context,
      MaterialPageRoute(
        builder: (_) => QuizResultPage(
          result: QuizRanking(position: 1, name: widget.userName, result: 100),
        ),
      ),
    );
  }

  Future<bool> blockReturn() {
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
            onPressed: !canFinish && answer != null ? next : null,
          ),
          IconButton(
            icon: const Icon(Icons.publish),
            tooltip: 'Finalizar',
            disabledColor: Colors.grey,
            onPressed: canFinish && answer != null ? finish : null,
          ),
        ],
      ),
      body: WillPopScope(
        onWillPop: () async {
          return blockReturn();
        },
        child: Padding(
            padding: EdgeInsets.fromLTRB(20, 20, 20, 20),
            child: Column(
                crossAxisAlignment: CrossAxisAlignment.stretch,
                children: <Widget>[
                  Text(
                      'Questão ${index + 1} - ${widget.quiz.questions[index].name}'),
                  DataTable(
                    columns: const <DataColumn>[
                      DataColumn(label: Text('')),
                      DataColumn(label: Text('')),
                    ],
                    rows: widget.quiz.questions[index].answers
                        .map(
                          ((element) => DataRow(
                                cells: <DataCell>[
                                  DataCell(Radio<Answer>(
                                    value: element,
                                    groupValue: answer,
                                    onChanged: (Answer newValue) {
                                      setState(() {
                                        answer = newValue;
                                      });
                                    },
                                  )),
                                  DataCell(Text(element.name)),
                                ],
                              )),
                        )
                        .toList(),
                  ),
                ])),
      ),
    );
  }
}
