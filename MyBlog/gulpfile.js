/// <binding BeforeBuild='sass' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/
var gulp = require('gulp'),
    sass = require("gulp-sass");

gulp.task('sass', function () {
    return gulp.src(['./wwwroot/lib/bootstrap/scss/bootstrap.scss','Styles/StyleSheet.scss'])
        .pipe(sass())
        .pipe(gulp.dest('wwwroot/css'));
});
