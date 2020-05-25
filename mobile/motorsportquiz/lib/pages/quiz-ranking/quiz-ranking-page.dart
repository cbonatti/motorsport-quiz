import 'package:flutter/material.dart';
import 'package:motorsportquiz/pages/quiz/pre-start-quiz-page.dart';

import 'models/quiz-ranking.dart';
import 'services/quiz-ranking-service.dart';

class QuizRankingPage extends StatefulWidget {
  @override
  _QuizRankingPageState createState() => _QuizRankingPageState();
}

class _QuizRankingPageState extends State<QuizRankingPage> {
  final QuizRankingService _rankingService = QuizRankingService();
  void _startQuiz(BuildContext context) {
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
              _startQuiz(context);
            },
          )
        ],
      ),
      body: Column(
        crossAxisAlignment: CrossAxisAlignment.stretch,
        children: <Widget>[
          FutureBuilder(
            future: _rankingService.getRanking(),
            builder: (BuildContext context,
                AsyncSnapshot<List<QuizRanking>> snapshot) {
              if (snapshot.hasData) {
                List<QuizRanking> ranking = snapshot.data;
                return DataTable(
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
                  rows: ranking
                      .map(
                        ((element) => DataRow(
                              cells: <DataCell>[
                                DataCell(Text(element.position
                                    .toString())), //Extracting from Map element the value
                                DataCell(Text(element.name)),
                                DataCell(Text(
                                    '${element.result.toStringAsFixed(2)}%')),
                              ],
                            )),
                      )
                      .toList(),
                );
              } else {
                return Center(child: CircularProgressIndicator());
              }
            },
          ),
        ],
      ),
    );
  }
}
