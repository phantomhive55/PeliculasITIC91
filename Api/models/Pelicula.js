'use strict';

const { Sequelize } = require('sequelize');
const sequelize = new Sequelize({
    dialect: 'sqlite',
    storage: './storage/database.sqlite'
});

 
const Pelicula = sequelize.define('Pelicula', {
    id: {
        primaryKey: true,
        type: Sequelize.BIGINT,
        autoIncrement: true
    },
    titulo: {
        type: Sequelize.STRING
    },
    genero: {
        type: Sequelize.STRING
    },
    duracion: {
        type: Sequelize.BIGINT
    },
    anio: {
        type: Sequelize.BIGINT
    }

});

Pelicula.sync();

module.exports = Pelicula;