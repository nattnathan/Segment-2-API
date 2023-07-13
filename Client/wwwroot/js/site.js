console.log("Latihan Javascript")

let judul = document.getElementById("judul");
let p1 = document.getElementsByTagName("p");

judul.onclick = ()=> {
    judul.style.backgroundColor = "cyan";
    judul.innerHTML = "Saya ubah dari JS";
}

let query = document.querySelector("li:nth-child(2)");


//query.onclick = () => {
//    p1[0].style.backgroundColor = "pink";
//    query.style.backgroundColor = "pink";
//}

//query.onclick = () => {
//    p1[0].innerHTML = "Berubahhh!";
//    query.innerHTML = "Berubahhhhhh!!!";
//}

query.addEventListener('click', () => {
    p1[0].style.backgroundColor = "pink";
    query.style.backgroundColor = "pink";
});

query.addEventListener('click', () => {
    p1[0].innerHTML = "Berubahhh!";
    query.innerHTML = "Berubahhhhhh!!!";
});

//array => sekumpulan variable dengan tipe data yang sama dan nama yang sama,
//int nilai[5] => [50,60,80,90,90]

let array = [1, 2, 3, 4, 5];
//console.log(array);
//array.push("testing")
//console.log(array);
//array.pop();
//console.log(array);
//array.unshift("haloo");
//console.log(array[0]);
//array.shift();
//console.log(array);

//array multidimensi
let arrayMulti = [1, 2, 3, ['a', 'b', 'c', true], false];
//console.log(arrayMulti);
//console.log(arrayMulti[3][3]);

//object vs array ?? => object = key and value, array = index
// {} vs []
let obj = {};
obj.testing = "halo";
obj.number = 50;
console.log(obj);

//cara manual
let user = {
    test: obj.testing,
    testnumber: obj.number,
    username: "iniusername",
    password: "inipasword"
}

console.log(user)

//dengan spread operator
let spread = {
    ...obj,
    spread: "test",
    spreadnumber: 90
}

console.log(spread);

//arrow function
let hitung = (x, y) => x + y;

//function hitung(x, y) {
//    return x+y
//}

console.log(hitung(5, 9));

//array of object
let arrayMhsObj = [
    { nama: "budi", nim: "a112015", umur: 20, isActive: true, fakultas:{name:"komputer"}},
    { nama: "joko", nim: "a112035", umur: 22, isActive: false, fakultas: { name: "ekonomi" }},
    { nama: "herul", nim: "a112020", umur: 21, isActive: true, fakultas: { name: "komputer" }},
    { nama: "herul", nim: "a112032", umur: 25, isActive: true, fakultas: { name: "ekonomi" }},
    { nama: "herul", nim: "a112040", umur: 21, isActive: true, fakultas: { name: "komputer" }},
]

let FakultasKomp = [];

FakultasKomp = arrayMhsObj.filter(mhs => mhs.fakultas.name == "komputer");

console.log(arrayMhsObj);
console.log(FakultasKomp);

//$.ajax({
//    url: "https://swapi.dev/api/people/"
//}).done((result) => {
//    console.log(result.results);
//    let temp = "";
//    $.each(result.results, (key, val) => {
//        temp += `<tr>
//                    <td>${key+1}</td>
//                    <td>${val.name}</td>
//                    <td>${val.height}</td>
//                    <td>${val.gender}</td>
//                    <td><button onclick="detail('${val.url}')" data-bs-toggle="modal" data-bs-target="#modalSW" class="btn btn-primary">Detail</button></td>
//                </tr>`;
//    })
//    $("#tbodySW").html(temp);

//})


function detail(stringURL) {
    $.ajax({
        url: stringURL
    }).done(res => {
        $(".modal-title").html(res.name);
    })
}

$(document).ready(function () {
    $('#myTable').DataTable({
        ajax: {
            url: "https://swapi.dev/api/people/",
            dataType: "JSON",
            dataSrc: "results" //data source -> butuh array of object
        },
        dom: 'Bfrtip', 
        buttons: [
            'colvis',
            'excel',
            'pdf',
            'print'
        ],
        columns: [
            { data : "name"},
            { data : "name"},
            {
                data: 'height',
                render: function (data, type, row) {
                    return data + ' cm';
                }
            },
            { data : "gender"},
            { data : "gender"}
        ]
    });
});