// UserController.js

var express = require('express');
var router = express.Router();
var bodyParser = require('body-parser');
router.use(bodyParser.urlencoded({ extended: true}));
router.use(bodyParser.json());

var User = require('./User');

// get users
router.get('/', function(req, res){
    User.find({}, 
        function(err, users){
            if (err) return res.status(500).send("There was a problem getting users");
            res.status(200).send(users);
        });
});

// get user/:id
router.get('/:id', function(req, res){
    User.findById(req.params.id, 
        function(err, user){
            if (err) return res.status(500).send("There was a problem finding user");
            if (!user) return res.status(404).send("No user found.");
            res.status(200).send(user);
        });
});

// new user
router.post('/', function(req, res){

    User.create({
        name : req.body.name,
        email : req.body.email,
        password : req.body.password
    },
    function (err, user){
        if (err) return res.status(500).send("There was a problem creating user");
        res.status(200).send(user);
    });
});

// update user
router.put('/:id', function(req, res){

    User.findByIdAndUpdate(req.params.id, req.body, { new: true},
    function (err, user){
        if (err) return res.status(500).send("There was a problem creating user");
        res.status(200).send(user);
    });
});


// delete user
router.delete('/:id', function(req, res){

    User.findByIdAndRemove(req.params.id, 
        function (err, user){
            if (err) return res.status(500).send("There was a problem creating user");
            res.status(200).send("User "+ user.name +" was deleted.");
        });
});

module.exports = router;