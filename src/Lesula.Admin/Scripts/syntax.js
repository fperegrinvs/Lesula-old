define(function (require, exports, module) {
    require("ace/lib/fixoldbrowsers");

    var theme = require("ace/theme/textmate");
    var EditSession = require("ace/edit_session").EditSession;
    var UndoManager = require("ace/undomanager").UndoManager;

    require("ace/mode/csharp");
    var Split = require("ace/split").Split;

    // Splitting.
    function initSplit(env, container) {
        var split = new Split(container, theme, 1);
        env.editor = split.getEditor(0);
        split.on("focus", function (editor) {
            env.editor = editor;
        });
        env.split = split;
    }

    function setDocument(env, value, text) {
        var doc = new EditSession(text);
        var r = require("ace/mode/" + value);
        var clazz = r.Mode;
        var mode = new clazz();
        doc.setMode(mode);
        doc.setUndoManager(new UndoManager());
        var session = env.split.setSession(doc);
        session.name = value;
        env.editor.focus();
    }

    function onResize(env, container) {
        var left = env.split.$container.offsetLeft;
        var width = document.documentElement.clientWidth - left - 80;
        container.style.width = width + "px";
        env.split.resize();
    }

    function initAce(containerList) {
        for (var i = 0; i < containerList.length; i++) {
            var container = containerList[i];
            var env = {};
            initSplit(env, container);
            window.onresize = onResize(env, container);
            env.editor.renderer.onResize(true);
            setDocument(env, dType[i], hlText[i]);
            onResize(env, container);
            editors.push(env.editor);
        }
    }

    editors = [];
    initAce($(".hlEditor"));
});
