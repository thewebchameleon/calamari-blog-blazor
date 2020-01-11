/// <binding BeforeBuild='build-css, build-scripts, build-scripts-framework' />
let gulp = require("gulp"),
    sass = require("gulp-sass"),
    autoprefixer = require("gulp-autoprefixer"),
    rename = require("gulp-rename"),
    concat = require('gulp-concat'),
    uglify = require('gulp-uglify-es').default,
    sourcemaps = require('gulp-sourcemaps');

gulp.task('build-css', function () {
    return gulp
        .src([
            './wwwroot/sass/framework.scss',
            './wwwroot/sass/site.scss'
        ])
        .pipe(sourcemaps.init())
        .pipe(sass({
            outputStyle: "compressed"
        }).on('error', sass.logError))
        .pipe(autoprefixer())
        .pipe(rename(function (path) {
            path.extname = ".min.css";
        }))
        .pipe(sourcemaps.write('./'))
        .pipe(gulp.dest("./wwwroot/css"));
});

gulp.task('build-scripts-framework', function () {
    return gulp
        .src([
            './node_modules/jquery/dist/jquery.min.js',
            './node_modules/bootstrap/dist/js/bootstrap.bundle.min.js',
            './node_modules/startbootstrap-clean-blog/js/clean-blog.min.js',
            './node_modules/webfontloader/webfontloader.js'
        ])
        .pipe(concat('framework.min.js'))
        .pipe(gulp.dest('./wwwroot/js'));
});

gulp.task('build-scripts', function () {
    return gulp
        .src([
            './wwwroot/js/site.js'
        ])
        .pipe(sourcemaps.init())
        .pipe(concat('site.min.js'))
        .pipe(uglify())
        .pipe(sourcemaps.write('./'))
        .pipe(gulp.dest('./wwwroot/js'));
});