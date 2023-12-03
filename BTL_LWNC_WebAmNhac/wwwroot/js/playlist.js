const $ = document.querySelector.bind(document);
const $$ = document.querySelectorAll.bind(document);


const app = {
    songs: [
        {
            name: "Cat doi noi sau",
            singer: "Thanh Dat",
            path: "catdoinoisau.mp3",
            image: "catdoinoisau.jpg",
        },
        {
            name: "Em la ai",
            singer: "Keyo",
            path: "emlaai.mp3",
            image: "emlaai.jpg",
        },
        {
            name: "Gap doi yeu thuong",
            singer: "Tuan Hung",
            path: "gapdoiyeuthuong.mp3",
            image: "gapdoiyeuthuong.jpg",
        },
        {
            name: "Em la ai",
            singer: "Keyo",
            path: "emlaai.mp3",
            image: "emlaai.jpg",
        },
        {
            name: "Gap doi yeu thuong",
            singer: "Tuan Hung",
            path: "gapdoiyeuthuong.mp3",
            image: "gapdoiyeuthuong.jpg",
        },
        {
            name: "Em la ai",
            singer: "Keyo",
            path: "emlaai.mp3",
            image: "emlaai.jpg",
        },
        {
            name: "Gap doi yeu thuong",
            singer: "Tuan Hung",
            path: "gapdoiyeuthuong.mp3",
            image: "gapdoiyeuthuong.jpg",
        }
    ],
    render: function () {
        const htmls = this.songs.map(song => {
            return `<div class="song">
            <div class="thumb" style="background-image: url('${song.image}')">
            </div>
            <div class="body">
                <h3 class="title">${song.name}</h3>
                <p class="author">${song.singer}</p>
            </div>
            <div class="option">
                <i class="fas fa-ellipsis-h"></i>
            </div>
        </div>`
        })
        $('.playlist').innerHTML = htmls.join('')
    },
    handleEvents: function () {
        cd = $('.cd')
        const cdWidth = cd.offsetWidth
        document.onscroll = function () {
            document.onscroll = function () {
                const scrollTop = window.scrollY || document.documentElement.scrollTop
                const newCdWidth = cdWidth - scrollTop

                cd.style.width = newCdWidth > 0 ? newCdWidth + 'px' : 0
                cd.style.opacity = newCdWidth / cdWidth

            }
        }
    },
    start: function () {
        this.handleEvents()
        this.render()
    }
}
app.start()


