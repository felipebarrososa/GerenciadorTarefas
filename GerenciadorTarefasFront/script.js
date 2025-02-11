document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('form-tarefa');
    const taskList = document.getElementById('task-list');
    const submitButton = document.getElementById('submit-btn');
    let currentTaskId = null; // Variável para armazenar o ID da tarefa em edição
    let tasks = []; // Variável global para armazenar as tarefas

    // Função para obter todas as tarefas
    const fetchTasks = async () => {
        try {
            const response = await fetch('http://localhost:5063/api/tarefa');
            if (!response.ok) throw new Error('Erro ao buscar tarefas');
            tasks = await response.json(); // Armazenando as tarefas na variável global
            renderTasks(tasks);
        } catch (error) {
            console.error('Erro ao carregar tarefas:', error);
        }
    };

    // Função para renderizar as tarefas na lista
    const renderTasks = (tasks) => {
        taskList.innerHTML = '';
        tasks.forEach(task => {
            const li = document.createElement('li');
            li.innerHTML = `
                <div>
                    <strong>${task.titulo}</strong>
                    <p>${task.descricao}</p>
                    <small>Status: ${task.status}</small>
                </div>
                <div class="task-actions">
                    <button class="edit" onclick="editTask(${task.id})">Alterar</button>
                    <button class="delete" onclick="deleteTask(${task.id})">Excluir</button>
                </div>
            `;
            taskList.appendChild(li);
        });
    };

    // Função para adicionar tarefa
    const addTask = async (task) => {
        try {
            const response = await fetch('http://localhost:5063/api/tarefa', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(task)
            });
            if (!response.ok) throw new Error('Erro ao adicionar tarefa');
            fetchTasks();  // Atualiza a lista de tarefas
        } catch (error) {
            console.error('Erro ao adicionar tarefa:', error);
        }
    };

    // Função para editar tarefa
    window.editTask = async (id) => {
        const task = tasks.find(task => task.id === id); // Agora 'tasks' está disponível globalmente
        currentTaskId = id; // Armazenando o ID da tarefa em edição

        // Preenche os campos com os dados da tarefa
        document.getElementById('titulo').value = task.titulo;
        document.getElementById('descricao').value = task.descricao;
        document.getElementById('status').value = task.status;

        // Altera o texto do botão para "Alterar Tarefa"
        submitButton.textContent = 'Alterar Tarefa';
    };

    // Função de envio de edição
    const editTaskSubmit = async (e) => {
        e.preventDefault();
    
        const titulo = document.getElementById('titulo').value;
        const descricao = document.getElementById('descricao').value;
        const status = document.getElementById('status').value;
    
        // Inclui o id no corpo da requisição conforme o Swagger sugere
        const updatedTask = {
            id: currentTaskId,
            titulo,
            descricao,
            status
        };
    
        console.log('Payload enviado:', updatedTask);
    
        try {
            const response = await fetch(`http://localhost:5063/api/Tarefa/${currentTaskId}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(updatedTask)
            });
    
            if (!response.ok) {
                const errorDetails = await response.text();
                throw new Error(`Erro ao editar tarefa: ${response.status} - ${errorDetails}`);
            }
    
            await fetchTasks();
            form.reset();
            submitButton.textContent = 'Adicionar Tarefa';
            currentTaskId = null;
        } catch (error) {
            console.error('Erro ao editar tarefa:', error);
            alert(`Erro ao editar tarefa: ${error.message}`);
        }
    };
      

    // Função para excluir tarefa
    window.deleteTask = async (id) => {
        try {
            const response = await fetch(`http://localhost:5063/api/tarefa/${id}`, {
                method: 'DELETE'
            });
            if (!response.ok) throw new Error('Erro ao excluir tarefa');
            fetchTasks();  // Atualiza a lista de tarefas
        } catch (error) {
            console.error('Erro ao excluir tarefa:', error);
        }
    };

    // Função para enviar dados do formulário para criar tarefa
    const addTaskListener = async (e) => {
        e.preventDefault();
        const titulo = document.getElementById('titulo').value;
        const descricao = document.getElementById('descricao').value;
        const status = document.getElementById('status').value;

        const task = { titulo, descricao, status };
        await addTask(task);
        form.reset();
    };

    form.addEventListener('submit', (e) => {
        if (currentTaskId) {
            // Se estamos editando uma tarefa, usamos a função de edição
            editTaskSubmit(e);
        } else {
            // Caso contrário, adicionamos uma nova tarefa
            addTaskListener(e);
        }
    });

    // Carregar tarefas quando a página carregar
    fetchTasks();
});
