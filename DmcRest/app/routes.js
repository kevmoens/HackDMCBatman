var express = require('express');
var router = express.Router();

var ITEM = require('../models/item');

// PING on appRoot
router.get('/', function(req, res) {
    res.json({ message: 'PING' });
});

router.get('/dub/:num',function(req,res){
    res.send({'result': parseInt(req.params.num) });
});

router.route('/items')
.get(function(req, res) {
        ITEM.find(function(err, item) {
            if (err){
                res.send(err);
            }
            res.json({items:item});

        }).limit(parseInt(30)).cursor();
    }
);

router.route('/items/:ltNum')
.get(function(req, res) {
    var query = ITEM.find({},{_id:0,department:0,dataitemid:0,begin_dt_tm:0,end_dt_tm:0}).limit(parseInt(req.params.ltNum));
        query.exec(function(err, items) {
            if (err){
                res.send(err);
            }
            res.json({items:items});

        });
    }
);

//Find machine given machine id
router.route('/items/machine/:machineId')
    .get(function(req, res) {
        var query = ITEM.find({machine_id:req.params.machineId},{_id:0,department:0,dataitemid:0,begin_dt_tm:0,end_dt_tm:0}).limit(1000).sort([['sequence','descending']]);
        query.exec(function (err, items) {
        if (err) return next(err);
        res.send({items:items});
    });
});

router.route('/items/alarm/:machineId')
    .get(function(req, res) {
        var query = ITEM.find({machine_id:req.params.machineId},{_id:0,department:0,dataitemid:0,begin_dt_tm:0,end_dt_tm:0})
        .where('category').equals('Alarm')
        .limit(1000).sort([['sequence','descending']]);

        query.exec(function (err, items) {
        if (err) return next(err);
        res.send({items:items});
    });
});

module.exports = router;
