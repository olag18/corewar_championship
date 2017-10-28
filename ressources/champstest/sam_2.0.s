.name		"SAM"
.comment	"Ca roxxe du chameau"

entry:
	sti		r1, %:wall, %1
	ld		%0, r16
	fork	%:shield_init
	st		r1, 6
	live	%21
	fork	%:machine_gun_init

wall_prep:
	ld		%0, r2
	ld		%0, r16

wall:
	live	%4902343
	st		r2, -50
	st		r2, -59
	st		r2, -68
	st		r2, -77
	st		r2, -86
	st		r2, -95
	st		r2, -104
	st		r2, -113
	st		r2, -122
	st		r2, -131
	st		r2, -140
	st		r2, -149
	st		r2, -158
	st		r2, -167
	st		r2, -176
	st		r2, -185
	st		r2, -194
	st		r2, -203
	zjmp	%:wall

shield_init:
	ld		%0, r2

shield:
	live	%21
	st		r2, 124
	st		r2, 124
	st		r2, 124
	st		r2, 124
	st		r2, 124
	st		r2, 124
	st		r2, 124
	st		r2, 124
	st		r2, 124
	st		r2, 124
	st		r2, 124
	st		r2, 124
	st		r2, 124
	zjmp	%:shield

machine_gun_init:
	st		r1, 6

machine_gun_gen:
	live	%42
	fork	%:machine_gun_gen
