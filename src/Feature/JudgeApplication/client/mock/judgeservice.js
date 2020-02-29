module.exports = {
  'GET /sitecore/api/judge/teams': function (req, res) {
    res.json([
      {"TeamName":"Sitecore Lunatic",
    "ID":"a", 
     "Judged":true},
    {"TeamName":"Sitecore Lunatic",
    "ID":"b"},
    {"TeamName":"Sitecore Lunatic",
    "ID":""},
    {"TeamName":"Sitecore Lunatic",
    "ID":""},
    ]);
  },
  'GET /sitecore/api/judge/detail': function (req, res) {
    res.json({"TeamName":"Sitecore Test",
  "Member":[{"Name":"TestName"}],
   "GitHubLink":"https://github.com/mitya88"});
  }
  ,
  'POST /sitecore/api/judge/sendpoint': function (req, res) {
    res.json({});
  }
};
