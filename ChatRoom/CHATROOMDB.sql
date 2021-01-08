create table room
(
    room_id  int auto_increment
        primary key,
    name     varchar(20)                   not null,
    type     varchar(20) default 'private' not null,
    capacity int         default 100       not null,
    owner    int                           null,
    guest    int                           null,
    constraint room_name_uindex
        unique (name)
);

create table user
(
    user_id        int auto_increment
        primary key,
    username       varchar(20)                         not null,
    password       varchar(20)                         not null,
    nickname       varchar(40)                         not null,
    last_call_time timestamp default CURRENT_TIMESTAMP not null,
    room_id        int                                 null,
    constraint user_nickname_uindex
        unique (nickname),
    constraint user_username_uindex
        unique (username),
    constraint user_room_room_id_fk
        foreign key (room_id) references room (room_id)
);

insert into user(username, password, nickname)
values ('admin', '000', 'Admin');

insert into room(name, type, capacity) values ('Hall','public',100)