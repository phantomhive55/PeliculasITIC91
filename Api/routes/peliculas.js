'use strict';

var Pelicula = require('../models/Pelicula');

var express = require('express');
var router = express.Router();

router.get('/', async function (req, res) {
    const peliculas = await Pelicula.findAll();
    res.json(peliculas);
});

router.delete('/:idPelicula', async function (req, res) {
    try {
        const { idPelicula } = req.params;
        let pelicula = await Pelicula.destroy({
            where: { id: idPelicula }
        });
        console.log(pelicula);
        res.json(pelicula);
    } catch (e) {
        res.send(e);
    }
});


router.post('/', async function (req, res) {
    let { Titulo, Genero, Duracion, Anio } = req.body;
    let pelicula = await Pelicula.create({
        titulo: Titulo,
        genero: Genero,
        duracion: Duracion,
        anio: Anio
    });

    res.json(pelicula);
});


router.put('/:idPelicula', async function (req, res) {
    try {
        const { idPelicula } = req.params;
        const { Titulo, Genero, Duracion, Anio } = req.body;

        let PeliculaAgregar = await Pelicula.update(
            {
                titulo: Titulo,
                genero: Genero,
                duracion: Duracion,
                anio: Anio
            },
            {
                where: { id: idPelicula }
            }
        );

        if (PeliculaAgregar.length > 0) {
            let pelicula = await Pelicula.findOne({ where: { id: idPelicula } });
            res.json(pelicula);
        }

    } catch (e) {
        res.send(e);
    }
});

module.exports = router;
