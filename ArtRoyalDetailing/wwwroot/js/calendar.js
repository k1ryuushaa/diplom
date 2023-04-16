
let calendar = document.querySelector('.calendar')

const month_names = ['Январь', 'Февраль', 'Март', 'Апрель', 'Май', 'Июнь', 'Июль', 'Август', 'Сентябрь', 'Октябрь', 'Ноябрь', 'Декабрь']

isLeapYear = (year) => {
    return (year % 4 === 0 && year % 100 !== 0 && year % 400 !== 0) || (year % 100 === 0 && year % 400 === 0)
}

getFebDays = (year) => {
    return isLeapYear(year) ? 29 : 28
}

generateCalendar = (month, year) => {

    let calendar_days = calendar.querySelector('.monthdays')
    let calendar_header_year = calendar.querySelector('#yearchange')

    let days_of_month = [31, getFebDays(year), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31]

    calendar_days.innerHTML = ''

    let currDate = new Date()
    if (month != 0 &&!month) month = currDate.getMonth()
    if (!year) year = currDate.getFullYear()
    let cur_month = `${month_names[month]}`
    calendar.querySelector('#monthchange').innerHTML = `${cur_month}<input type="hidden" name="month" value="${month+1}"/>`
    calendar_header_year.innerHTML = `${year}<input type="hidden" name="year" value="${year}" />`


    let first_day = new Date(year, month, 1)

    for (let i = 1; i <= days_of_month[month] + first_day.getDay() - 1; i++) {
        let day = document.createElement('button')
        if (i>= first_day.getDay()) {
            day.classList.add('day')
            day.name = "day"
            day.value = `${i - first_day.getDay() + 1}`
            day.type='submit'
            day.addEventListener('click', () => getSelectedDate((i - first_day.getDay() + 1), month+1,year))
            day.innerHTML = i - first_day.getDay() + 1
            if (i - first_day.getDay() + 1 === currDate.getDate() && year === currDate.getFullYear() && month === currDate.getMonth()) {
                day.classList.add('curr-day')
            }
        }
        else {
            day.classList.add('day-false')
            day.disabled='disabled'
        }
        calendar_days.appendChild(day)
    }
}

const month_list = calendar.querySelector('.monthchangecal')

month_names.forEach((e, index) => {
    let month = document.createElement('span')
    month.innerHTML = `<span data-month="${index}">${e}</span>`
    month.querySelector('span').onclick = () => {
        curr_month.value = index
        generateCalendar(index, curr_year.value)
        changeMonthShow(false)
    }
    month_list.appendChild(month)
})

calendar.querySelector('#monthchange').onclick = () => {
    changeMonthShow(true)
}

let currDate = new Date()
let curr_month = { value: currDate.getMonth() }
let curr_year = { value: currDate.getFullYear() }


changeMonthShow = (boolean) => {
    if (boolean != true) {
        calendar.querySelector('.monthyear').style.display = 'flex'
        calendar.querySelector('.week-days').style.display = 'grid'
        calendar.querySelector('.monthdays').style.display = 'grid'
        calendar.querySelector('.monthchangecal').style.display = 'none'
    }
    else {
        calendar.querySelector('.monthyear').style.display = 'none'
        calendar.querySelector('.week-days').style.display = 'none'
        calendar.querySelector('.monthdays').style.display = 'none'
        calendar.querySelector('.monthchangecal').style.display = 'grid'
    }
}

generateCalendar(curr_month.value, curr_year.value)

document.querySelector('#prev-year').onclick = () => {
    --curr_year.value
    generateCalendar(curr_month.value, curr_year.value)
}

document.querySelector('#next-year').onclick = () => {
    ++curr_year.value
    generateCalendar(curr_month.value, curr_year.value)
}


