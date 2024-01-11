import telebot
import webbrowser
from token import bot
from telebot import types

#Обработчики команд
@bot.message_handler(commands=['start'])
def main(message):
    markup = types.InlineKeyboardMarkup()
    btn1 = types.InlineKeyboardButton('Установщик', callback_data='deleete')
    btn2 = types.InlineKeyboardButton('Ключ-активации', callback_data='delete')
    btn3 = types.InlineKeyboardButton('Подсказки', callback_data='delete')
    btn4 = types.InlineKeyboardButton('Задать вопрос', callback_data='delete')
    markup.row(btn1,btn3)
    markup.row(btn2, btn4)
    bot.send_message(message.chat.id, f'Привет, {message.from_user.first_name}, прежде чем перейти к установке, нужно выполнить несколько действий:'
                                      f' \n\n 1. загрузить установочный файл при помощи кнопки "Установщик"\n\n'
                                      f' 2. После загрузки установщика нажать кнопку "Ключ активации"'
                                      f'\n \n\nДальнейшие действия будут дописаны...', reply_markup=markup)


@bot.message_handler(commands=['help'])
def main(message):
    markup = types.InlineKeyboardMarkup()
    markup.add(types.InlineKeyboardButton('Задать вопрос', url='https://t.me/error_arch'))
    bot.send_message(message.chat.id, '<em>Справочная информация:</em>\n'
                                      ' если возникли одни из следующих проблем нажмите на кнопку:\n'
                                      ' Проблема 1;\n Проблема 2;\n Проблема 3;\n Проблема 4;\n', parse_mode='html', reply_markup=markup)









#Обработчики текста
@bot.message_handler()
def info(message):
    if message.text.lower() == 'привет':
        bot.send_message(message.chat.id, f'Привет, {message.from_user.first_name} {message.from_user.last_name}')
    elif message.text.lower() == 'id':
        bot.reply_to(message, f'ID: {message.from_user.id}')








bot.infinity_polling()