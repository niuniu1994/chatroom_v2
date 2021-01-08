create database if not exists CHATROOMDB;
use CHATROOMDB;


create table if not exists room (
    room_id int(10) not null primary key auto_increment,
    name varchar(20) not null
)ENGINE = InnoDB default charset = utf8;


create table if not exists user (
    user_id int(20) not null primary key auto_increment,
    username varchar(30) not null ,
    password varchar(30) not null ,
    nickname varchar(40) not null ,
    last_call_time timestamp default current_timestamp,
    room_id int(10),
    CONSTRAINT `fk_user_room` FOREIGN KEY (`room_id`) references room (`room_id`)
)ENGINE = InnoDB DEFAULT charset =utf8;