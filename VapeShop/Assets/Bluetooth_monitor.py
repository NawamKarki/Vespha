import bluetooth
import sys
import matplotlib.pyplot as plt
import csv
import os
import time
import zmq

context = zmq.Context()
socket = context.socket(zmq.REP)
socket.bind("tcp://*:5555")

from time import gmtime, strftime

#path for the folder and file to be created
curdir = os.path.dirname(__file__)
savedir = time.strftime('%Y-%m-%d')
savepath = os.path.join(curdir + "/Data/SensorData", savedir)

def data2int(data_string):
	ls = data_string[0]
	ms = data_string[1]
	ls_val = int(bin(ord(ls)),2)
	ms_val = int(bin(ord(ms)),2)
	return ms_val * 256 + ls_val

def search_devices():
	nearby_devices = bluetooth.discover_devices(lookup_names=True)
	print("found %d devices" % len(nearby_devices))

	for addr, name in nearby_devices:
		print("  %s - %s" % (addr, name)) 

#create folder based on the date 
def create_folder():
	try:
		os.makedirs(savepath)
	except:
		pass

def key_press(event):
	if (event.key == "m"):
		print("m key press event")
		global draw_line 
		draw_line = 1

def main():
	create_folder()

	# create file to store data
	out_file = open(strftime(savepath +"/participant " + pptNo + ".csv", gmtime()), "wb")

	enable_sum = '\x02\xbd\x02\x01\x00\xc4\x03'
	enable_gen = '\x02\x14\x01\x01\x01\x03'
	battery =  '\x02\xac\x00\x00\x03'
	lifesign = '\x02\x23\x00\x00\x03'

	sock = bluetooth.BluetoothSocket( bluetooth.RFCOMM )

	#MAC addresses for two devices
	#sock.connect(("A0:E6:F8:FA:91:E3",1))
	sock.connect(("A0:E6:F8:FA:97:62", 1)) #yellow sensor

	print("Connected")
	itterator = 0
	counter = 0
	xdata = []
	ydata = []
	y2data = []
	plot_data = True
	sock.send(enable_sum)
	global draw_line
	draw_line = 0
	
	data_out = csv.writer(out_file)
	data_out.writerow(["Time", "HRV","Breathing Rate", "Marker", "Heart Rate"])
	if (plot_data):
		plt.ion()
		fig, ax1 = plt.subplots()
		ax1.set_ylabel('Milliseconds')
		ax1.set_xlabel('Time since start')
		ax2 = ax1.twinx()
		ax2.set_ylabel('bpm')
		ax1.plot(xdata,ydata,'b', label="HRV")
		ax2.plot(xdata,y2data,'r', label="BR")
		ax1.legend(loc=2)
		ax2.legend(loc=1)
		
		cid = fig.canvas.mpl_connect('key_press_event', key_press)
	while 1:
		data = sock.recv(100) 
		if (data[1] == '\x23'):
			print("Lifesign packet")
		elif (data[1] == '\x2b'):
			print("Summary data packet")
			if (plot_data):
				BR = data2int(data[15:17])/10
				HRV = data2int(data[38:40])
				HR = data2int(data[13:15])
				HRV_Conf = int(bin(ord(data[37])),2)
				
				xdata.append(itterator)
				if (HRV == 65535):
					ydata.append(0)
				else:
					ydata.append(HRV)
				y2data.append(BR)
				if (draw_line == 1):
					draw_line = 0
					data_out.writerow([itterator, HRV, BR, itterator, HR])
					plt.axvline(x=itterator)
					print("Marker Placed")
				else:
					data_out.writerow([itterator, HRV, BR, 0, HR])
				if (len(xdata) == 300):
					xdata.pop(0)
					y2data.pop(0)
					plt.xlim(itterator-300,itterator)
				if (len(ydata) == 300):
					ydata.pop(0)
				
				ax1.plot(xdata,ydata,'b', label="HRV")
				ax2.plot(xdata,y2data,'r', label="BR")
				plt.title('HRV=' + str(HRV) + ' BR=' + str(BR) + '\n' + 'HR= ' + str(HR) + ' HRV Conf=' + str(HRV_Conf))
				plt.pause(0.10)
				itterator = itterator + 1
		elif (data[1] == '\xac'):
			print("Battery status")
			print(ord(data[-1]))
		elif (data[1] == '\xbd'):
			print("Summary Enable response")
		elif (data[1] == '\x14'):
			print("General Enable response")
		elif (data[1] == '\x20'):
			print("General Data Packet")
		else:
			print(ord(data[1]))
			print(ord(data[-1]))
		if counter == 2:
			counter = 0
			sock.send(lifesign)
			print("Send Lifesign")
		
		counter = counter + 1
#try:
#    main()

while True:
    pptNo = socket.recv()
	#print(message)
    if (pptNo):
        main()

#finally:
   #     out_file.close()
