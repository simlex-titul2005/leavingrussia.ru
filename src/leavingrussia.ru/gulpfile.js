/// <binding Clean='clean' />
"use strict";

var promise = require('es6-promise'),
    gulp = require('gulp'),
    del = require('del'),
    concat = require('gulp-concat'),
    autoprefixer = require('gulp-autoprefixer'),
    cleanCSS = require('gulp-clean-css'),
    watch = require('gulp-watch'),
    merge = require('merge-stream'),
    less = require('gulp-less'),
    uglify = require('gulp-uglify'),
    order = require('gulp-order');

var paths = {
    webroot: "./wwwroot/"
};

//clear all client side site files
function clear() {
    del([
        paths.webroot + 'css/**/*.css',
        paths.webroot + 'js/**/*.js',
    ]);
}

//create css
function createCss() {
    var lessStream = gulp.src([
       'less/site.less',
       'less/sticky-footer.less'
    ])
        .pipe(less())
        .pipe(cleanCSS({ compatibility: 'ie8' }))
        .pipe(autoprefixer('last 2 version', 'safari 5', 'ie 8', 'ie 9'))
        .pipe(concat('siteCss.css'));

    var cssStream = gulp.src([
        paths.webroot + 'lib/bootstrap/dist/css/bootstrap.min.css'
    ])
        .pipe(concat('css.css'));

    var mergedStream = merge(lessStream, cssStream)
        .pipe(order([
            'css.css',
            'siteCss.css'
        ]))
        .pipe(concat('site.min.css'))
        .pipe(gulp.dest(paths.webroot + 'css'));
}

//create css
function createJs() {
    var js = gulp.src([
        paths.webroot + 'lib/jquery/dist/jquery.min.js',
        paths.webroot + 'lib/bootstrap/dist/js/bootstrap.min.js'
    ])
        .pipe(concat('js.js'));

    var siteJs=gulp.src([
        'js/site.js'
    ])
        .pipe(uglify())
        .pipe(concat('siteJs.js'));

    var mergedStream = merge(js, siteJs)
        .pipe(order([
            'js.js',
            'siteJs.js'
        ]))
        .pipe(concat('site.min.js'))
        .pipe(gulp.dest(paths.webroot + 'js'));
}

gulp.task('watch', function (cb) {
    watch([
        'less/**/*.less',
        'js/**/*.js'
    ], function () {
        clear();
        createCss();
        createJs();
    });
});