import telebot
import webbrowser
from token import bot
from telebot import types

#Обработчики команд
@bot.message_handler(commands=['start'])
def main(message):
    markup = types.InlineKeyboardMarkup()
    markup.add(types.InlineKeyboardButton('Установщик', callback_data='deleete'))
    markup.add(types.InlineKeyboardButton('Ключ-активации', callback_data='delete'))
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
                                      ' Проблема 1;\nПроблема 2;\nПроблема 3;\nПроблема 4;\n', parse_mode='html', reply_markup=markup)

#Обработчики текста
@bot.message_handler()
def info(message):
    if message.text.lower() == 'привет':
        bot.send_message(message.chat.id, f'Привет, {message.from_user.first_name} {message.from_user.last_name}')
    elif message.text.lower() == 'id':
        bot.reply_to(message, f'ID: {message.from_user.id}')

bot.infinity_polling()