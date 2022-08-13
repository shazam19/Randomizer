// following tutorial at: https://youtu.be/ozgLMTdocac?t=453

window.playMedia = function (element) {
    element.load();
    element.play();
}

window.resetMedia = function (element) {
    element.pause();
    element.load();
}