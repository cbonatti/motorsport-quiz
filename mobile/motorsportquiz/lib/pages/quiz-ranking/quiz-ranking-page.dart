import 'package:flutter/material.dart';
import 'package:motorsportquiz/pages/quiz/pre-start-quiz-page.dart';
import 'package:motorsportquiz/pages/quiz/quiz-page.dart';

import 'models/quiz-ranking.dart';

class QuizRankingPage extends StatefulWidget {
  final List<QuizRanking> ranking = <QuizRanking>[
    QuizRanking(position: 1, name: 'Carlos', result: 10),
    QuizRanking(position: 2, name: 'Carlos', result: 100),
    QuizRanking(position: 3, name: 'Carlos', result: 50),
    QuizRanking(position: 4, name: 'Enrico', result: 100),
    QuizRanking(position: 5, name: 'Enrico', result: 100),
    QuizRanking(position: 6, name: 'Gabriela', result: 100),
    QuizRanking(position: 7, name: 'Carlos', result: 80),
  ];
  @override
  _QuizRankingPageState createState() => _QuizRankingPageState();
}

class _QuizRankingPageState extends State<QuizRankingPage> {
  void openPage(BuildContext context) {
    Navigator.push(
      context,
      MaterialPageRoute(
        builder: (_) => PreStartQuizPage(),
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Motorsport Quiz'),
        actions: <Widget>[
          IconButton(
            icon: const Icon(Icons.play_arrow),
            tooltip: 'Iniciar Quiz',
            onPressed: () {
              openPage(context);
            },
          )
        ],
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.start,
          children: <Widget>[
            Column(
              crossAxisAlignment: CrossAxisAlignment.stretch,
              children: <Widget>[
                DataTable(
                  columns: const <DataColumn>[
                    DataColumn(
                      label: Text(
                        '#',
                        style: TextStyle(fontStyle: FontStyle.italic),
                      ),
                    ),
                    DataColumn(
                      label: Text(
                        'Nome',
                        style: TextStyle(fontStyle: FontStyle.italic),
                      ),
                    ),
                    DataColumn(
                      label: Text(
                        'Potuação',
                        style: TextStyle(fontStyle: FontStyle.italic),
                      ),
                    ),
                  ],
                  rows: widget.ranking
                      .map(
                        ((element) => DataRow(
                              cells: <DataCell>[
                                DataCell(Text(element.position
                                    .toString())), //Extracting from Map element the value
                                DataCell(Text(element.name)),
                                DataCell(Text(element.result.toString())),
                              ],
                            )),
                      )
                      .toList(),
                )
              ],
            )
          ],
        ),
      ),
    );
  }
}
