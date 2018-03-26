/*
代表我的游戏区的模块
这个游戏区调用game.js
*/
var local = function () {
    //游戏对象
    var game;
    //时间间隔
    var INTERVAL = 200;
    var time = null;
    //绑定键盘事件
    var bindKeyEvent = function () {
        document.onkeydown = function (e) {
            if (e.keyCode == 38) {//up
                game.rotate();
            }
            else if (e.keyCode == 39) {//right
                game.right();
            } else if (e.keyCode == 40) {//down
                game.down();
            } else if (e.keyCode == 37) {//left
                game.left();
            } else if (e.keyCode == 32) {//space
                game.fall();
            }
        }
    }
    var move = function () {
        if (!game.down()) {
            game.fixed();
        }
    }
    //开始方法
    var start = function () {
        var doms = {
            gameDiv: document.getElementById('game'),
            nextDiv: document.getElementById('next')
        }
        game = new Game();
        game.init(doms);
        bindKeyEvent();
        timer = setInterval(move, INTERVAL);
    }
    //导出API
    this.start = start;
}