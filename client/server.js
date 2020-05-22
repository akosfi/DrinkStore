const express = require('express');

const app = express();

app.use(express.static('dist'));


app.get('/', function(req, res){
    res.sendfile('index.html', { root: __dirname + "/dist" } );
});

app.get('/Hi', (req, res, next) => res.send('Server is running!'));

app.listen(process.env.PORT || 8080);