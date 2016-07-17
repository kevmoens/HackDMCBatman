var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var ItemSchema = new Schema({
    begin_dt_tm: Date,
    category: String,
    component: String,
    dataitemid: String,
    department: [Number],
    duration_in_seconds: Date,
    end_dt_tm: Date,
    instance_id: Number,
    machine_id: Number,
    mt_name: String,
    mt_value: String,
    sequence: Number,
    sub_type: String,
    type: String,
    virtual_flag: String
});

module.exports = mongoose.model('Item', ItemSchema);
