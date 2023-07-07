function hideButton() {
    let button = document.getElementById('button5');
    let button2 = document.getElementById('button6')
    button.style.display = 'none';
    button2.style.display = 'inline-block'
    console.log("hide");
}

function showButton() {
    let button = document.getElementById('button5');
    let button2 = document.getElementById('button6');
    button.style.display = 'inline-block';
    button2.style.display = 'none';
    console.log("show");
}

function changeColor(rowId, bgColorClass, textColorClass) {
    let row = document.getElementById(rowId);
    row.classList.toggle(bgColorClass);
    row.classList.toggle(textColorClass);
    console.log("TEST 1");
}

function resetColors() {
    let rows = document.querySelectorAll('.row.border .border');
    rows.forEach(function (row) {
        row.classList.remove('bg-primary', 'bg-success', 'bg-info');
        row.classList.remove('text-light');
        console.log("TEST 2");
    });
}

// array of objek
let arrayMhsObj = [
    { nama: "budi", nim: "a112015", umur: 20, isActive: true, fakultas: { name: "komputer" } },
    { nama: "joko", nim: "a112035", umur: 22, isActive: false, fakultas: { name: "ekonomi" } },
    { nama: "herul", nim: "a112020", umur: 21, isActive: true, fakultas: { name: "komputer" } },
    { nama: "herul", nim: "a112032", umur: 25, isActive: true, fakultas: { name: "ekonomi" } },
    { nama: "herul", nim: "a112040", umur: 21, isActive: true, fakultas: { name: "komputer" } },
]

let fakultasKomputer = [];
let getFakultasKomputer = (arrayName) => {
    for (let i = 0; i < arrayName.length; i++)
    {
        // No 1
        if (arrayName[i].fakultas.name == "komputer")
        {
            fakultasKomputer.push(arrayName[i]);
        }

        // No 2
        if (parseInt(arrayName[i].nim.slice(-2)) >= 30) {
            arrayName[i].isActive = false;
        }
    }
    console.log(fakultasKomputer);
    console.log(arrayName);
}
getFakultasKomputer(arrayMhsObj);




/*let validateIsActive = (arrayName) => {
    for (let i = 0; i < arrayName.length; i++)
    {
        if (parseInt(arrayName[i].nim.slice(-2)) >= 30)
        {
            arrayName[i].isActive = false;
        }
    }
    console.log(arrayName);
}

validateIsActive(arrayMhsObj);
*/
