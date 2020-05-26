import 'package:flutter/material.dart';
import 'package:motorsportquiz/pages/quiz-ranking/models/quiz-ranking.dart';
import 'package:motorsportquiz/pages/quiz-ranking/quiz-ranking-page.dart';
import 'package:motorsportquiz/shared/components/circle-progress.dart';

import 'models/question.dart';
import 'quiz-page.dart';
import 'services/quiz-service.dart';

class QuizResultPage extends StatefulWidget {
  QuizResultPage({@required this.result});
  final QuizRanking result;

  @override
  _QuizResultPageState createState() => _QuizResultPageState();
}

class _QuizResultPageState extends State<QuizResultPage>
    with SingleTickerProviderStateMixin {
  final QuizService _quizService = QuizService();
  AnimationController progressController;
  Animation<double> animation;

  @override
  void initState() {
    super.initState();
    progressController = AnimationController(
        vsync: this, duration: Duration(milliseconds: 2000));
    animation = Tween<double>(begin: 0, end: widget.result.result)
        .animate(progressController)
          ..addListener(() {
            setState(() {});
          });

    progressController.forward();
  }

  void _startQuiz() {
    _quizService.start(widget.result.name).then((value) => {navigate(value)});
  }

  void navigate(List<Question> questions) {
    Navigator.push(
      context,
      MaterialPageRoute(
        builder: (_) => QuizPage(
          userName: widget.result.name,
          questions: questions,
        ),
      ),
    );
  }

  Future<bool> _goToRanking(BuildContext context) {
    Navigator.push(
      context,
      MaterialPageRoute(
        builder: (_) => QuizRankingPage(),
      ),
    );
    return Future.value(false);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      bottomNavigationBar: FlatButton(
        color: Colors.indigo,
        textColor: Colors.white,
        onPressed: _startQuiz,
        child: Text(
          "Reiniciar",
          style: TextStyle(fontSize: 20.0),
        ),
      ),
      appBar: AppBar(
        title: Text('Motorsport Quiz'),
      ),
      body: WillPopScope(
          onWillPop: () async {
            return _goToRanking(context);
          },
          child: Padding(
              padding: EdgeInsets.fromLTRB(20, 20, 20, 20),
              child: Center(
                  child: Column(
                children: <Widget>[
                  Text(
                    'Seu resultado',
                    style: TextStyle(fontSize: 20.0),
                  ),
                  CustomPaint(
                    foregroundPainter: CircleProgress(animation.value.toInt()),
                    child: Container(
                      width: 200,
                      height: 200,
                      child: GestureDetector(
                          child: Center(
                              child: Text(
                        "${animation.value.toInt()}%",
                        style: TextStyle(
                            fontSize: 30, fontWeight: FontWeight.bold),
                      ))),
                    ),
                  ),
                ],
              )))),
    );
  }
}
