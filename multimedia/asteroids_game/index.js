function application() {
    const canvas = document.getElementById('game')
    const context = canvas.getContext('2d');

    const lives_value = document.getElementById('lives_val');
    const score_value = document.getElementById('score_val');

    const overContainer = document.getElementById('over_container');
    const btnStart = document.getElementById('btn_start');
    const nameInputContainer = document.getElementById('name_input_container');
    const btnSave = document.getElementById('btn_save_score');
    const playerName = document.getElementById('player_name');
    const btnStop = document.getElementById('btn_stop');
    btnStop.classList.add('hidden');

    let gameOver;

    overContainer.classList.remove('hidden');
    nameInputContainer.classList.add('hidden');

    btnStart.addEventListener('click', function() {
        gameOver = false;
        ship.lives = 3;
        ship.score = 0;
        update_stats();
        overContainer.classList.add('hidden');
        game_loop();
    });


    btnStop.addEventListener('click', function() {
        ship.lives = 0;
        update_stats();
        gameOver = true;
        overContainer.classList.remove('hidden');
        btnStart.classList.add('hidden');
        nameInputContainer.classList.remove('hidden');
        displayHighScores();
    });

    function update_stats() {
        lives_value.textContent = ship.lives;
        score_value.textContent = ship.score;
    }

    function canvas_resize() {
        canvas.width = window.innerWidth;
        canvas.height = window.innerHeight;
    }

    window.addEventListener('resize', canvas_resize);
    canvas_resize();

    const keys = {};

    window.addEventListener('keydown', function(e) {
        keys[e.code] = true;
    });

    window.addEventListener('keyup', function(e) {
        keys[e.code] = false;
    });

    let asteroids = [];
    const no_asteroids = 10;

    for (let i = 0; i < no_asteroids; i++) {
        let initLifeAsteroid = Math.floor(Math.random() * 4) + 1;
        let asteroid = {
            x: Math.random() * canvas.width,
            y: Math.random() * canvas.height,
            radius: initLifeAsteroid * 10,
            life: initLifeAsteroid,
            speedX: (Math.random() - 0.5) * 2,
            speedY: (Math.random() - 0.5) * 2
        };
        asteroids.push(asteroid);
    }

    function collisions() {
        for (let i = 0; i < asteroids.length; i++) {
            for (let j = i + 1; j < asteroids.length; j++) {
                let dx = asteroids[i].x - asteroids[j].x;
                let dy = asteroids[i].y - asteroids[j].y;
                let distance = Math.sqrt(dx * dx + dy * dy);

                if (distance < asteroids[i].radius + asteroids[j].radius) {
                    asteroids[i].speedX *= -1;
                    asteroids[i].speedY *= -1;
                    asteroids[j].speedX *= -1;
                    asteroids[j].speedY *= -1;
                }
            }
        }
    }

    let ship = {
        x: canvas.width / 2,
        y: canvas.height / 2,
        radius: 30,
        angle: 2 * Math.PI,
        speed: 5,
        lives: 3,
        score: 0,
        lastBonusScore: 0
    };

    let rockets = [];
    let shoot = true;

    function drawShip() {
        context.save();
        context.translate(ship.x, ship.y);
        context.rotate(ship.angle);

        context.strokeStyle = 'salmon';
        context.lineWidth = 8;
        context.beginPath();
        context.moveTo(0, -ship.radius);
        context.lineTo(ship.radius, ship.radius);
        context.lineTo(0, ship.radius / 2);
        context.lineTo(-ship.radius, ship.radius);
        context.closePath();
        context.stroke();

        context.restore();
    }

    function setAsteroidColor(life) {
        if (life === 4) return'brown';
        else if(life === 3) return 'orange';
        else if(life === 2) return 'yellow';
        return 'white';
    }

    function drawAsteroid() {
        let initLifeAsteroid = Math.floor(Math.random() * 4) + 1;
        let asteroid = {
            x: Math.random() * canvas.width,
            y: Math.random() * canvas.height,
            radius: initLifeAsteroid * 10,
            life: initLifeAsteroid,
            speedX: (Math.random() - 0.5) * 2,
            speedY: (Math.random() - 0.5) * 2
        };
        asteroids.push(asteroid);
    }

    function game_loop() {
        btnStop.classList.remove('hidden');
        if (gameOver === true) {
            context.clearRect(0, 0, canvas.width, canvas.height);
            return;
        }

        context.clearRect(0, 0, canvas.width, canvas.height);

        if (keys['KeyZ']) ship.angle -= 0.05;
        if (keys['KeyC']) ship.angle += 0.05;

        if (keys['ArrowUp']) {
            ship.x += Math.sin(ship.angle) * ship.speed;
            ship.y -= Math.cos(ship.angle) * ship.speed;
        }

        if (keys['ArrowDown']) {
            ship.x -= Math.sin(ship.angle) * ship.speed;
            ship.y += Math.cos(ship.angle) * ship.speed;
        }

        if (keys['ArrowLeft']) {
            ship.x -= Math.cos(ship.angle) * ship.speed;
            ship.y -= Math.sin(ship.angle) * ship.speed;
        }

        if (keys['ArrowRight']) {
            ship.x += Math.cos(ship.angle) * ship.speed;
            ship.y += Math.sin(ship.angle) * ship.speed;
        }

        if (keys['KeyX'] && rockets.length < 3 && shoot) {
            rockets.push({
                x: ship.x + Math.sin(ship.angle) * ship.radius,
                y: ship.y - Math.cos(ship.angle) * ship.radius,
                vx: Math.sin(ship.angle) * 10,
                vy: -Math.cos(ship.angle) * 10,
                radius: 4
            });
            shoot = false;
        }

        if (!keys['KeyX']) shoot = true;

        rockets.forEach((rocket, rIndex) => {
            rocket.x += rocket.vx;
            rocket.y += rocket.vy;

            context.beginPath();
            context.arc(rocket.x, rocket.y, rocket.radius, 0, Math.PI * 2);
            context.fillStyle = 'red';
            context.fill();

            if (rocket.x < 0 || rocket.x > canvas.width || rocket.y < 0 || rocket.y > canvas.height) {
                rockets.splice(rIndex, 1);
            }

            asteroids.forEach((asteroid, aIndex) => {
                let dx = rocket.x - asteroid.x;
                let dy = rocket.y - asteroid.y;
                let distance = Math.sqrt(dx * dx + dy * dy);

                if (distance < asteroid.radius) {
                    rockets.splice(rIndex, 1);
                    asteroid.life--;

                    if (asteroid.life <= 0) {
                        asteroids.splice(aIndex, 1);
                        ship.score += 10;
                        drawAsteroid();
                        update_stats();
                    }

                    if(ship.score % 50 === 0 && ship.score !== ship.lastBonusScore) {
                        ship.lives ++;
                        ship.lastBonusScore = ship.score;
                        update_stats();
                    }
                }
            });
        });

        if(ship.x < 0) ship.x = canvas.width;
        if(ship.x > canvas.width) ship.x = 0;
        if(ship.y < 0) ship.y = canvas.height;
        if(ship.y > canvas.height) ship.y = 0;

        collisions();

        asteroids.forEach(asteroid => {
            asteroid.x += asteroid.speedX;
            asteroid.y += asteroid.speedY;

            if (asteroid.x < 0) asteroid.x = canvas.width;
            if (asteroid.x > canvas.width) asteroid.x = 0;
            if (asteroid.y < 0) asteroid.y = canvas.height;
            if (asteroid.y > canvas.height) asteroid.y = 0;

            let dx = ship.x - asteroid.x;
            let dy = ship.y - asteroid.y;
            let distance = Math.sqrt(dx * dx + dy * dy);

            if (distance < ship.radius + asteroid.radius) {
                ship.lives--;
                update_stats();

                ship.x = canvas.width / 2;
                ship.y = canvas.height / 2;
            }

            context.beginPath();
            context.arc(asteroid.x, asteroid.y, asteroid.radius, 0, Math.PI * 2);
            
            context.strokeStyle = setAsteroidColor(asteroid.life);

            context.lineWidth = 3;
            context.stroke();

            context.fillStyle = 'white';
            context.font = '20px Courier New';
            context.textAlign = 'center';
            context.textBaseline = 'middle';
            context.fillText(asteroid.life, asteroid.x, asteroid.y);

        });

        if (ship.lives <= 0) {
            gameOver = true;
            overContainer.classList.remove('hidden');
            btnStart.classList.add('hidden');
            nameInputContainer.classList.remove('hidden');
            return;
        }

        drawShip();

        requestAnimationFrame(game_loop);
    }

    update_stats();
    displayHighScores();

    function displayHighScores() {
        const list = document.getElementById('highscores_list');
        if (!list) return;
        list.innerHTML = '';
        let highScores = JSON.parse(localStorage.getItem('asteroids_scores')) || [];

        highScores.forEach(entry => {
            const li = document.createElement('li');
            li.textContent = `${entry.name}: ${entry.score}`;
            list.appendChild(li);
        });
    }

    btnSave.addEventListener('click', function() {
        const name = playerName.value || 'unknown';
        let highScores = JSON.parse(localStorage.getItem('asteroids_scores')) || [];
        const existingEntryIndex = highScores.findIndex(entry => entry.name === name);
        if (existingEntryIndex !== -1) {
            if (ship.score > highScores[existingEntryIndex].score) {
                highScores[existingEntryIndex].score = ship.score;
                alert('Well done! A new record of yourself!');
            } else {
                alert('You did not beat your previous score.');
            }
        } else {
            highScores.push({ name: name, score: ship.score });
        }
        highScores.sort((a, b) => b.score - a.score);
        highScores = highScores.slice(0, 5);
        localStorage.setItem('asteroids_scores', JSON.stringify(highScores));
        displayHighScores();
        alert('Score saved! Lets play again.');
        location.reload();
    });

    
}

document.addEventListener('DOMContentLoaded', application);