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

/*$.ajax({
    url: "https://pokeapi.co/api/v2/pokemon/"
}).done((result) => {
    console.log(result.results);
    let temp = "";
    $.each(result.results, (key, val) => {
        temp += `<tr>
                    <td>${key + 1}</td>
                    <td>${val.name}</td>
                    <td><button onclick="detail('${val.url}')" data-bs-toggle="modal" data-bs-target="#modal" class="btn btn-info">Detail</button></td>
                </tr>`;
    })
    $("#tbody").html(temp);
    console.log(temp);
})*/

function detail(stringURL) {
    $.ajax({
        url: stringURL
    }).done(res => {
        $(".modal-title").html(res.name);

        $("#image-front").attr("src", res.sprites.other.dream_world.front_default);

        let stats = "";
        res.stats.forEach(stat => {
            let percentage = (stat.base_stat / 255) * 100; // Menghitung persentase
            let statBar = `<div class="stat-bar">
                                <div class="stat-fill" style="width: ${percentage}%"></div>
                           </div>`;
            stats += `<div style="margin-bottom: 1px; background-color: white; border-radius: 8px">${stat.stat.name + ": " + stat.base_stat} ${statBar}</div>`;
        });
        $(".stats").html(stats);

        let abilities = "";
        res.abilities.forEach(ability => {
            let color = "";
            let backgroundColor = "";
            if (ability.ability.name === "overgrow") {
                backgroundColor = "#006400"; // Hijau gelap
                color = "white";
            } else if (ability.ability.name === "chlorophyll") {
                backgroundColor = "#32CD32"; // Hijau terang
                color = "white";
            } else if (ability.ability.name === "blaze") {
                backgroundColor = "#FF4500"; // Merah terang
                color = "white";
            } else if (ability.ability.name === "solar") {
                backgroundColor = "#FFD700"; // Kuning
                color = "white";
            } else if (ability.ability.name === "torrent") {
                backgroundColor = "#1E90FF"; // Biru laut
                color = "white";
            } else if (ability.ability.name === "rain-dish") {
                backgroundColor = "#87CEEB"; // Biru langit
                color = "black";
            } else if (ability.ability.name === "shield-dust") {
                backgroundColor = "#C0C0C0"; // Abu-abu perak
                color = "black";
            } else if (ability.ability.name === "run-away") {
                backgroundColor = "#8B4513"; // Cokelat
                color = "white";
            } else if (ability.ability.name === "shed-skin") {
                backgroundColor = "#F5F5DC"; // Kulit
                color = "black";
            } else if (ability.ability.name === "compound-eyes") {
                backgroundColor = "#4B0082"; // Ungu gelap
                color = "white";
            } else if (ability.ability.name === "swarm") {
                backgroundColor = "#B8860B"; // Kuning gelap
                color = "white";
            } else if (ability.ability.name === "sniper") {
                backgroundColor = "#000080"; // Biru tua
                color = "white";
            } else if (ability.ability.name === "keen-eye") {
                backgroundColor = "#FFFF00"; // Kuning muda
                color = "black";
            } else if (ability.ability.name === "tangled-feet") {
                backgroundColor = "#D3D3D3"; // Abu-abu muda
                color = "black";
            } else if (ability.ability.name === "big-pecks") {
                backgroundColor = "#FFC0CB"; // Merah muda
                color = "black";
            } else if (ability.ability.name === "guts") {
                backgroundColor = "#FF0000"; // Merah
                color = "white";
            } else if (ability.ability.name === "hustle") {
                backgroundColor = "#696969"; // Abu-abu tua
                color = "white";
            } else {
                backgroundColor = "#0000FF"; // Warna default jika tidak ada yang cocok
                color = "white";
            }
            abilities += `<span style="margin: 5px; display: inline-block; text-align: center; background-color:${backgroundColor}; color: ${color}; border-radius: 8px; padding: 3px; font-family: 'Comic Sans MS'">${ability.ability.name}</span>`;
        });
        $("#abilities").html(abilities);

        let types = "";
        res.types.forEach(type => {
            let backgroundColor = ""; // Warna latar belakang
            let color = "";
            let iconClass = ""; // Kelas ikon Font Awesome
            if (type.type.name === "fire") {
                backgroundColor = "#FF4500"; // Merah terang
                color = "white";
                iconClass = "fas fa-fire"; // Ikon api
            } else if (type.type.name === "water") {
                backgroundColor = "#1E90FF"; // Biru laut
                color = "white";
                iconClass = "fas fa-water"; // Ikon air
            } else if (type.type.name === "grass") {
                backgroundColor = "#228B22"; // Hijau daun
                color = "white";
                iconClass = "fas fa-leaf"; // Ikon rumput
            } else if (type.type.name === "poison") {
                backgroundColor = "#9932CC"; // Ungu tua
                color = "white";
                iconClass = "fas fa-skull-crossbones"; // Ikon racun
            } else if (type.type.name === "flying") {
                backgroundColor = "#87CEEB"; // Biru langit
                color = "black";
                iconClass = "fas fa-dove"; // Ikon terbang
            } else if (type.type.name === "bug") {
                backgroundColor = "#9ACD32"; // Hijau cerah
                color = "black";
                iconClass = "fas fa-bug"; // Ikon serangga
            } else if (type.type.name === "normal") {
                backgroundColor = "#A9A9A9"; // Abu-abu tua
                color = "black";
                iconClass = "fas fa-circle"; // Ikon normal
            } else if (type.type.name === "electric") {
                backgroundColor = "#FFD700"; // Kuning
                color = "black";
                iconClass = "fas fa-bolt"; // Ikon petir
            } else if (type.type.name === "ice") {
                backgroundColor = "#00BFFF"; // Biru langit cerah
                color = "black";
                iconClass = "fas fa-snowflake"; // Ikon es
            } else if (type.type.name === "fighting") {
                backgroundColor = "#8B0000"; // Merah gelap
                color = "white";
                iconClass = "fas fa-fist-raised"; // Ikon bertarung
            } else if (type.type.name === "ground") {
                backgroundColor = "#DEB887"; // Cokelat muda
                color = "black";
                iconClass = "fas fa-mountain"; // Ikon tanah
            } else if (type.type.name === "psychic") {
                backgroundColor = "#FF1493"; // Merah muda cerah
                color = "white";
                iconClass = "fas fa-brain"; // Ikon psikis
            } else if (type.type.name === "rock") {
                backgroundColor = "#A0522D"; // Cokelat tua
                color = "white";
                iconClass = "fas fa-mountain"; // Ikon batu
            } else if (type.type.name === "ghost") {
                backgroundColor = "#4B0082"; // Ungu tua gelap
                color = "white";
                iconClass = "fas fa-ghost"; // Ikon hantu
            } else if (type.type.name === "dragon") {
                backgroundColor = "#9932CC"; // Ungu tua
                color = "white";
                iconClass = "fas fa-dragon"; // Ikon naga
            } else if (type.type.name === "dark") {
                backgroundColor = "#2F4F4F"; // Abu-abu gelap
                color = "white";
                iconClass = "fas fa-moon"; // Ikon gelap
            } else if (type.type.name === "steel") {
                backgroundColor = "#A9A9A9"; // Abu-abu tua
                color = "white";
                iconClass = "fas fa-shield-alt"; // Ikon baja
            } else if (type.type.name === "fairy") {
                backgroundColor = "#FF69B4"; // Merah muda terang
                color = "black";
                iconClass = "fas fa-magic"; // Ikon peri
            } else {
                backgroundColor = "#000000"; // Warna default jika tidak ada yang cocok
                color = "white";
                iconClass = "fas fa-question"; // Ikon default jika tidak ada yang cocok
            }

            types += `<span style="margin: 5px; display: inline-block; text-align: center; background-color: ${backgroundColor}; color: ${color}; border-radius: 8px; padding: 3px; font-family: 'Comic Sans MS'"><i class="${iconClass}"></i> ${type.type.name}</span>`;
        });
        $("#types").html(types);

        let weight = res.weight
        let weightFormatted = (weight/10).toLocaleString('en-US');
        weightFormatted = weightFormatted.replace('.', ',');

        $("#weight").html(weightFormatted);

        let height = res.height
        let heightFormatted = (height / 10).toLocaleString('en-US');
        heightFormatted = heightFormatted.replace('.', ',');
        $("#height").html(heightFormatted);

        $("#base-experience").html(res.base_experience);
    });
}

//Table Pokemon
$(document).ready(function () {
    $('#myTable').DataTable({
        ajax: {
            url: "https://pokeapi.co/api/v2/pokemon/?limit=100",
            dataType: "json",
            dataSrc: "results"
        },
        columns: [
            {
                data: 'no',
                render: function (data, type, row, meta) {
                    return meta.row + 1;
                }
            },
            { data: "name" },
            {
                data: 'action',
                render: function (data, type, row) {
                    return '<button onclick="detail(\'' + row.url + '\')" data-bs-toggle="modal" data-bs-target="#modal" class="btn btn-info">Detail</button>';
                }
            }
        ]
    });
});

//Table Employee
$(document).ready(function () {
    moment.locale('id');
    $('#myTable2').DataTable({
        ajax: {
            url: "https://localhost:7256/api/employees",
            dataType: "json",
            dataSrc: "data"
        },
        dom: 'Bfrtip',
        buttons: [
            'colvis', 'copy', 'csv',
            {
                extend: 'excelHtml5',
                title: 'Excel',
                text: 'Export to excel',
                className: "btn-primary",
                //Columns to export
                exportOptions: {
                     columns: [0, 1, 2, 3,4,5,6,7]
                }
            },
            {
                extend: 'pdfHtml5',
                title: 'PDF',
                text: 'Export to PDF',
                //Columns to export
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6,7]
                }
            },
            {
                extend: 'print',
                exportOptions: {
                    columns: ':visible'
                }
            }
        ],
        autoWidth: false,
        columns: [
            {
                data: 'no',
                render: function (data, type, row, meta) {
                    return meta.row + 1;
                }
            },
            { data: "nik" },
            {
                data: 'fullName',
                render: function (data, type, row) {
                    return row.firstName + ' ' + row.lastName;
                }   
            },
            {
                //data: "birthDate"
                data: "birthDate",
                render: function (data, type, row) {
                    return moment(data).format("DD MMMM YYYY");
                }
            },
            {
                data: "gender",
                render: function (data, type, row) {
                    if (data === 0) {
                        return "Female";
                    } else if (data === 1) {
                        return "Male";
                    } else {
                        return "";
                    }
                }
            },
            {
                //data: "hiringDate"
                data: "hiringDate",
                render: function (data, type, row) {
                    return moment(data).format("DD MMMM YYYY");
                }
            },
            { data: "email" },
            { data: "phoneNumber" },
            {
                data: 'action',
                render: function (data, type, row) {
                    return '<button onclick="detail(\'' + row.url + '\')" data-bs-toggle="modal" data-bs-target="#modal" class="btn btn-info">Detail</button>';
                }
            }
        ],
    });
});