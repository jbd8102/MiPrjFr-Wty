//ControlID is the name of the div that is going to be displayed
function OpenJQueryModalDialog(controlID, title) {
    var controle;
    controle = '#' + controlID;
    $(controle).dialog
        ({
            dialogClass: "ui-dialog-titlebar",
            title: title,
            show: "scale",
            width: 530,
            height: 470,
            position: "center",
            modal: true,
            resizable: false,
            buttons:
            [
                {
                    text: "Fermer la fenêtre",
                    class: "btn btn-info",
                    click: function ()
                    {
                        $(this).dialog("close");
                    }

                }
            ]
        });
}
