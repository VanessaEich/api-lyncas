const tabela = document.querySelector("tbody");
var delay = null;

function BuscarUsuarios(value) {
    clearTimeout(delay);
    delay = setTimeout(function () {
        for (let i = 0; tabela.rows.length - 1; i++) {
            let row = tabela.rows[i];
            if (row == undefined) {
                return;
            }
            if (!row.cells[0].innerText.toLowerCase().includes(value.toLowerCase()) &&
                !row.cells[1].innerText.toLowerCase().includes(value.toLowerCase()) &&
                !row.cells[2].innerText.toLowerCase().includes(value.toLowerCase()) &&
                !row.cells[3].innerText.toLowerCase().includes(value.toLowerCase()) &&
                !row.cells[4].innerText.toLowerCase().includes(value.toLowerCase())
            ) {
                row.hidden = true;
            } else {
                row.hidden = false;
            }
        }
    }, 1000)
}